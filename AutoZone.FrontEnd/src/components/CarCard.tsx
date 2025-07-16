import React from 'react';
import { Card, CardContent, CardMedia, Typography, Button, Box, Chip } from '@mui/material';
import { DirectionsCar, AttachMoney, Speed } from '@mui/icons-material';
import { useNavigate } from 'react-router';
import { Car } from '../app/slices/inventorySlice';

interface CarCardProps {
  car: Car;
}

const CarCard: React.FC<CarCardProps> = ({ car }) => {
  const navigate = useNavigate();

  const handleViewDetails = () => {
    navigate(`/cars/${car.id}`);
  };

  const formatPrice = (price: number) => {
    return new Intl.NumberFormat('en-US', {
      style: 'currency',
      currency: 'USD',
    }).format(price);
  };

  const formatMileage = (mileage: number) => {
    return new Intl.NumberFormat('en-US').format(mileage);
  };

  return (
    <Card
      sx={{
        height: '100%',
        display: 'flex',
        flexDirection: 'column',
        transition: 'transform 0.2s ease-in-out',
        '&:hover': {
          transform: 'translateY(-4px)',
          boxShadow: '0 8px 16px rgba(0,0,0,0.2)',
        },
      }}>
      <CardMedia component='img' height='200' image={car.images[0]} alt={`${car.year} ${car.make} ${car.model}`} sx={{ objectFit: 'cover' }} />
      <CardContent sx={{ flexGrow: 1, display: 'flex', flexDirection: 'column' }}>
        <Typography variant='h6' component='h2' gutterBottom>
          {car.year} {car.make} {car.model}
        </Typography>

        <Box sx={{ display: 'flex', alignItems: 'center', mb: 1 }}>
          <AttachMoney color='primary' sx={{ mr: 0.5 }} />
          <Typography variant='h5' color='primary' fontWeight='bold'>
            {formatPrice(car.price)}
          </Typography>
        </Box>

        <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
          <Speed color='secondary' sx={{ mr: 0.5 }} />
          <Typography variant='body2' color='text.secondary'>
            {formatMileage(car.mileage)} miles
          </Typography>
        </Box>

        <Box sx={{ mb: 2 }}>
          {car.features.slice(0, 3).map((feature, index) => (
            <Chip key={index} label={feature} size='small' sx={{ mr: 0.5, mb: 0.5 }} />
          ))}
        </Box>

        <Box sx={{ mt: 'auto' }}>
          <Button variant='contained' fullWidth onClick={handleViewDetails} startIcon={<DirectionsCar />}>
            View Details
          </Button>
        </Box>
      </CardContent>
    </Card>
  );
};

export default CarCard;
