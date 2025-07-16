import React from 'react';
import { Box, Typography, Slider, TextField } from '@mui/material';

interface SearchFiltersProps {
  filters: {
    priceRange: [number, number];
    yearRange: [number, number];
    make: string;
    model: string;
  };
  onFilterChange: (filters: { priceRange: [number, number]; yearRange: [number, number]; make: string; model: string }) => void;
}

const SearchFilters: React.FC<SearchFiltersProps> = ({ filters, onFilterChange }) => {
  const handlePriceChange = (_event: unknown, newValue: number | number[]) => {
    onFilterChange({ ...filters, priceRange: newValue as [number, number] });
  };

  const handleYearChange = (_event: unknown, newValue: number | number[]) => {
    onFilterChange({ ...filters, yearRange: newValue as [number, number] });
  };

  const handleMakeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    onFilterChange({ ...filters, make: event.target.value });
  };

  const handleModelChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    onFilterChange({ ...filters, model: event.target.value });
  };

  return (
    <Box sx={{ p: 2 }}>
      <Typography variant='h6' gutterBottom>
        Search Filters
      </Typography>

      <Box sx={{ mb: 3 }}>
        <Typography gutterBottom>Price Range</Typography>
        <Slider value={filters.priceRange} onChange={handlePriceChange} valueLabelDisplay='auto' min={0} max={100000} step={1000} />
      </Box>

      <Box sx={{ mb: 3 }}>
        <Typography gutterBottom>Year Range</Typography>
        <Slider value={filters.yearRange} onChange={handleYearChange} valueLabelDisplay='auto' min={1990} max={2024} step={1} />
      </Box>

      <Box sx={{ mb: 3 }}>
        <TextField fullWidth label='Make' value={filters.make} onChange={handleMakeChange} margin='normal' />
      </Box>

      <Box sx={{ mb: 3 }}>
        <TextField fullWidth label='Model' value={filters.model} onChange={handleModelChange} margin='normal' />
      </Box>
    </Box>
  );
};

export default SearchFilters;
