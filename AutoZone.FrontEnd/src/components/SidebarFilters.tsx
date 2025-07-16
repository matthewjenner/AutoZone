import React from 'react';
import { Box, Typography, Slider, TextField, FormControl, InputLabel, Select, MenuItem, Checkbox, FormControlLabel, Accordion, AccordionSummary, AccordionDetails, Button } from '@mui/material';
import { ExpandMore } from '@mui/icons-material';

interface SidebarFiltersProps {
  filters: {
    priceRange: [number, number];
    yearRange: [number, number];
    engineSize: string;
    doors: number[];
    make: string;
    model: string;
    inStockOnly: boolean;
    newArrivals: boolean;
  };
  onFilterChange: (filters: {
    priceRange: [number, number];
    yearRange: [number, number];
    engineSize: string;
    doors: number[];
    make: string;
    model: string;
    inStockOnly: boolean;
    newArrivals: boolean;
  }) => void;
  onClearFilters: () => void;
}

const SidebarFilters: React.FC<SidebarFiltersProps> = ({ filters, onFilterChange, onClearFilters }) => {
  const handlePriceChange = (_event: Event, newValue: number | number[]) => {
    onFilterChange({ ...filters, priceRange: newValue as [number, number] });
  };

  const handleYearChange = (_event: Event, newValue: number | number[]) => {
    onFilterChange({ ...filters, yearRange: newValue as [number, number] });
  };

  const handleEngineSizeChange = (event: React.ChangeEvent<HTMLInputElement> | Event) => {
    onFilterChange({ ...filters, engineSize: (event.target as { value: string }).value });
  };

  const handleDoorsChange = (doorValue: number, checked: boolean) => {
    let newDoors = [...filters.doors];
    if (checked) {
      // Add the door value if not already present
      if (!newDoors.includes(doorValue)) {
        newDoors.push(doorValue);
      }
    } else {
      // Remove the door value
      newDoors = newDoors.filter(door => door !== doorValue);
    }
    onFilterChange({ ...filters, doors: newDoors });
  };

  const handleMakeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    onFilterChange({ ...filters, make: event.target.value });
  };

  const handleModelChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    onFilterChange({ ...filters, model: event.target.value });
  };

  const handleInStockChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    onFilterChange({ ...filters, inStockOnly: event.target.checked });
  };

  const handleNewArrivalsChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    onFilterChange({ ...filters, newArrivals: event.target.checked });
  };

  return (
    <Box sx={{ width: 280, p: 2, bgcolor: 'background.paper' }}>
      <Typography variant='h6' gutterBottom>
        Filters
      </Typography>

      <Accordion defaultExpanded>
        <AccordionSummary expandIcon={<ExpandMore />}>
          <Typography>Price Range</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Slider value={filters.priceRange} onChange={handlePriceChange} valueLabelDisplay='auto' min={0} max={100000} step={1000} />
        </AccordionDetails>
      </Accordion>

      <Accordion defaultExpanded>
        <AccordionSummary expandIcon={<ExpandMore />}>
          <Typography>Year Range</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Slider value={filters.yearRange} onChange={handleYearChange} valueLabelDisplay='auto' min={1990} max={2024} step={1} />
        </AccordionDetails>
      </Accordion>

      <Accordion>
        <AccordionSummary expandIcon={<ExpandMore />}>
          <Typography>Engine Size</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <FormControl fullWidth>
            <InputLabel>Engine Size</InputLabel>
            <Select value={filters.engineSize} onChange={handleEngineSizeChange}>
              <MenuItem value=''>Any</MenuItem>
              <MenuItem value='1.0L'>1.0L</MenuItem>
              <MenuItem value='1.5L'>1.5L</MenuItem>
              <MenuItem value='2.0L'>2.0L</MenuItem>
              <MenuItem value='2.5L'>2.5L</MenuItem>
              <MenuItem value='3.0L'>3.0L</MenuItem>
              <MenuItem value='3.6L'>3.6L</MenuItem>
              <MenuItem value='5.0L'>5.0L</MenuItem>
              <MenuItem value='6.4L'>6.4L</MenuItem>
            </Select>
          </FormControl>
        </AccordionDetails>
      </Accordion>

      <Accordion>
        <AccordionSummary expandIcon={<ExpandMore />}>
          <Typography>Doors</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Box sx={{ display: 'flex', flexDirection: 'column', gap: 1 }}>
            {[2, 3, 4, 5].map(doorValue => (
              <FormControlLabel
                key={doorValue}
                control={<Checkbox checked={filters.doors.includes(doorValue)} onChange={event => handleDoorsChange(doorValue, event.target.checked)} />}
                label={`${doorValue} doors`}
              />
            ))}
          </Box>
        </AccordionDetails>
      </Accordion>

      <Accordion>
        <AccordionSummary expandIcon={<ExpandMore />}>
          <Typography>Make & Model</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <TextField fullWidth label='Make' value={filters.make} onChange={handleMakeChange} margin='normal' />
          <TextField fullWidth label='Model' value={filters.model} onChange={handleModelChange} margin='normal' />
        </AccordionDetails>
      </Accordion>

      <Accordion>
        <AccordionSummary expandIcon={<ExpandMore />}>
          <Typography>Availability</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <FormControlLabel control={<Checkbox checked={filters.inStockOnly} onChange={handleInStockChange} />} label='In Stock Only' />
          <FormControlLabel control={<Checkbox checked={filters.newArrivals} onChange={handleNewArrivalsChange} />} label='New Arrivals' />
        </AccordionDetails>
      </Accordion>
      <Box sx={{ mt: 3, pt: 2, borderTop: 1, borderColor: 'divider' }}>
        <Button variant='outlined' fullWidth onClick={onClearFilters} sx={{ mt: 1 }}>
          Clear All Filters
        </Button>
      </Box>
    </Box>
  );
};

export default SidebarFilters;
