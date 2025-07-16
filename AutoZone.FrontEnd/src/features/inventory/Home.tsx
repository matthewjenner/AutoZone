import React, { useEffect, useState, useMemo } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../app/store';
import { fetchCars } from '../../app/slices/inventorySlice';
import { Container, Typography, Box, Grid, Card, CardMedia, CardContent, Button, Chip, FormControl, InputLabel, Select, MenuItem } from '@mui/material';
import { DirectionsCar, Speed, CalendarToday } from '@mui/icons-material';
import HeroCarousel from '../../components/HeroCarousel';
import SidebarFilters from '../../components/SidebarFilters';
import { Car } from '../../app/slices/inventorySlice';

const Home: React.FC = () => {
  const dispatch = useDispatch();
  const { cars, loading, error } = useSelector((state: RootState) => state.inventory);
  const [sortBy, setSortBy] = useState('price-low');
  const [filters, setFilters] = useState({
    priceRange: [0, 100000] as [number, number],
    yearRange: [1990, 2024] as [number, number],
    engineSize: '',
    doors: [] as number[],
    make: '',
    model: '',
    inStockOnly: false,
    newArrivals: false,
  });

  useEffect(() => {
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    dispatch(fetchCars(undefined) as any);
  }, [dispatch]);

  const handleSortChange = (event: React.ChangeEvent<HTMLInputElement> | Event) => {
    setSortBy((event.target as { value: string }).value);
  };

  const handleFilterChange = (newFilters: {
    priceRange: [number, number];
    yearRange: [number, number];
    engineSize: string;
    doors: number[];
    make: string;
    model: string;
    inStockOnly: boolean;
    newArrivals: boolean;
  }) => {
    setFilters(newFilters);
  };

  const handleClearFilters = () => {
    setFilters({
      priceRange: [0, 100000] as [number, number],
      yearRange: [1990, 2024] as [number, number],
      engineSize: '',
      doors: [] as number[],
      make: '',
      model: '',
      inStockOnly: false,
      newArrivals: false,
    });
  };

  // Filter and sort the cars
  const filteredAndSortedCars = useMemo(() => {
    if (!cars || cars.length === 0) return [];

    let filtered = cars.filter((car: Car) => {
      // Price filter
      if (car.price < filters.priceRange[0] || car.price > filters.priceRange[1]) {
        return false;
      }

      // Year filter
      if (car.year < filters.yearRange[0] || car.year > filters.yearRange[1]) {
        return false;
      }

      // Engine size filter
      if (filters.engineSize && car.engineSize !== filters.engineSize) {
        return false;
      }

      // Doors filter
      if (filters.doors.length > 0 && !filters.doors.includes(car.doors)) {
        return false;
      }

      // Make filter
      if (filters.make && !car.make.toLowerCase().includes(filters.make.toLowerCase())) {
        return false;
      }

      // Model filter
      if (filters.model && !car.model.toLowerCase().includes(filters.model.toLowerCase())) {
        return false;
      }

      // In stock filter
      if (filters.inStockOnly && !car.inStock) {
        return false;
      }

      // New arrivals filter
      if (filters.newArrivals && !car.isNewArrival) {
        return false;
      }

      return true;
    });

    // Sort the filtered cars
    switch (sortBy) {
      case 'price-low':
        filtered.sort((a, b) => a.price - b.price);
        break;
      case 'price-high':
        filtered.sort((a, b) => b.price - a.price);
        break;
      case 'year-new':
        filtered.sort((a, b) => b.year - a.year);
        break;
      case 'year-old':
        filtered.sort((a, b) => a.year - b.year);
        break;
      case 'mileage-low':
        filtered.sort((a, b) => a.mileage - b.mileage);
        break;
      case 'mileage-high':
        filtered.sort((a, b) => b.mileage - a.mileage);
        break;
      default:
        break;
    }

    return filtered;
  }, [cars, filters, sortBy]);

  if (loading) {
    return (
      <Container maxWidth='xl' sx={{ py: 4 }}>
        <Typography>Loading...</Typography>
      </Container>
    );
  }

  if (error) {
    return (
      <Container maxWidth='xl' sx={{ py: 4 }}>
        <Typography color='error'>{error}</Typography>
      </Container>
    );
  }

  return (
    <Box>
      {/* Hero Carousel */}
      <HeroCarousel />

      {/* Main Content */}
      <Container maxWidth='xl' sx={{ py: 4 }}>
        {/* Header with Sort */}
        <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', mb: 4 }}>
          <Typography variant='h4' component='h1'>
            Available Vehicles ({filteredAndSortedCars.length})
          </Typography>

          <FormControl sx={{ minWidth: 200 }}>
            <InputLabel>Sort By</InputLabel>
            <Select value={sortBy} label='Sort By' onChange={handleSortChange}>
              <MenuItem value='price-low'>Price: Low to High</MenuItem>
              <MenuItem value='price-high'>Price: High to Low</MenuItem>
              <MenuItem value='year-new'>Year: Newest First</MenuItem>
              <MenuItem value='year-old'>Year: Oldest First</MenuItem>
              <MenuItem value='mileage-low'>Mileage: Low to High</MenuItem>
              <MenuItem value='mileage-high'>Mileage: High to Low</MenuItem>
            </Select>
          </FormControl>
        </Box>

        {/* Content Grid */}
        <Box sx={{ display: 'flex', gap: 3 }}>
          {/* Sidebar Filters */}
          <SidebarFilters filters={filters} onFilterChange={handleFilterChange} onClearFilters={handleClearFilters} />

          {/* Vehicle Grid */}
          <Box sx={{ flex: 1 }}>
            <Grid container spacing={3}>
              {filteredAndSortedCars.map(car => (
                <Grid size={{ xs: 12, sm: 6, md: 4, lg: 3 }} key={car.id}>
                  <Card sx={{ height: '100%', display: 'flex', flexDirection: 'column' }}>
                    <CardMedia component='img' height='200' image={car.images[0] || 'https://picsum.photos/400/200'} alt={`${car.year} ${car.make} ${car.model}`} />
                    <CardContent sx={{ flexGrow: 1, display: 'flex', flexDirection: 'column' }}>
                      <Typography variant='h6' component='h3' gutterBottom>
                        {car.year} {car.make} {car.model}
                      </Typography>

                      <Typography variant='h5' color='primary' fontWeight='bold' gutterBottom>
                        ${car.price.toLocaleString()}
                      </Typography>

                      <Box sx={{ display: 'flex', alignItems: 'center', mb: 1 }}>
                        <Speed sx={{ mr: 1, fontSize: 'small', color: 'text.secondary' }} />
                        <Typography variant='body2' color='text.secondary'>
                          {car.mileage.toLocaleString()} miles
                        </Typography>
                      </Box>

                      <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
                        <CalendarToday sx={{ mr: 1, fontSize: 'small', color: 'text.secondary' }} />
                        <Typography variant='body2' color='text.secondary'>
                          {car.engineSize} • {car.doors} doors
                        </Typography>
                      </Box>

                      <Box sx={{ display: 'flex', gap: 1, mb: 2, flexWrap: 'wrap' }}>
                        {car.inStock && <Chip label='In Stock' color='success' size='small' />}
                        {car.isNewArrival && <Chip label='New Arrival' color='primary' size='small' />}
                      </Box>

                      <Button variant='contained' fullWidth startIcon={<DirectionsCar />} sx={{ mt: 'auto' }}>
                        View Details
                      </Button>
                    </CardContent>
                  </Card>
                </Grid>
              ))}
            </Grid>
          </Box>
        </Box>
      </Container>
    </Box>
  );
};

export default Home;
