import React, { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../app/store';
import { fetchCarById } from '../../app/slices/inventorySlice';
import { Container, Grid, Card, CardMedia, Typography, Box, Chip, Button, Paper } from '@mui/material';
import { ArrowBack, Phone, Email, LocationOn } from '@mui/icons-material';

const CarDetail: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { cars, loading, error } = useSelector((state: RootState) => state.inventory);

  // Find the car by id from the inventory
  const car = cars.find(c => c.id === id);

  useEffect(() => {
    if (id) {
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      dispatch(fetchCarById(id) as any);
    }
  }, [dispatch, id]);

  if (loading) {
    return (
      <Container maxWidth='lg' sx={{ py: 4 }}>
        <Typography>Loading...</Typography>
      </Container>
    );
  }

  if (error || !car) {
    return (
      <Container maxWidth='lg' sx={{ py: 4 }}>
        <Typography color='error'>Car not found</Typography>
      </Container>
    );
  }

  return (
    <Container maxWidth='lg' sx={{ py: 4 }}>
      <Box sx={{ mb: 3 }}>
        <Button startIcon={<ArrowBack />} onClick={() => navigate(-1)} sx={{ mb: 2 }}>
          Back to Inventory
        </Button>
        <Typography variant='h4' component='h1' gutterBottom>
          {car.year} {car.make} {car.model}
        </Typography>
      </Box>

      <Grid container spacing={4}>
        {/* Image Gallery */}
        <Grid size={{ xs: 12, md: 8 }}>
          <Card>
            <CardMedia component='img' height='400' image={car.images[0] || 'https://picsum.photos/800/600'} alt={`${car.year} ${car.make} ${car.model}`} />
          </Card>
        </Grid>

        {/* Car Details */}
        <Grid size={{ xs: 12, md: 4 }}>
          <Paper sx={{ p: 3, mb: 3 }}>
            <Typography variant='h5' component='h2' gutterBottom>
              ${car.price.toLocaleString()}
            </Typography>

            <Box sx={{ mb: 3 }}>
              <Typography variant='body2' color='text.secondary' gutterBottom>
                {car.mileage.toLocaleString()} miles
              </Typography>
              <Typography variant='body2' color='text.secondary' gutterBottom>
                {car.engineSize} • {car.doors} doors
              </Typography>
            </Box>

            <Button variant='contained' fullWidth size='large' sx={{ mb: 2 }}>
              Contact Dealer
            </Button>

            <Button variant='outlined' fullWidth size='large'>
              Schedule Test Drive
            </Button>
          </Paper>

          {/* Dealer Info */}
          <Paper sx={{ p: 3 }}>
            <Typography variant='h6' gutterBottom>
              AutoZone Dealership
            </Typography>
            <Box sx={{ mb: 2 }}>
              <Box sx={{ display: 'flex', alignItems: 'center', mb: 1 }}>
                <LocationOn sx={{ mr: 1, color: 'text.secondary' }} />
                <Typography variant='body2'>123 Main Street, Anytown, USA</Typography>
              </Box>
              <Box sx={{ display: 'flex', alignItems: 'center', mb: 1 }}>
                <Phone sx={{ mr: 1, color: 'text.secondary' }} />
                <Typography variant='body2'>(555) 123-4567</Typography>
              </Box>
              <Box sx={{ display: 'flex', alignItems: 'center' }}>
                <Email sx={{ mr: 1, color: 'text.secondary' }} />
                <Typography variant='body2'>sales@autozone.com</Typography>
              </Box>
            </Box>
          </Paper>
        </Grid>

        {/* Specifications */}
        <Grid size={{ xs: 12 }}>
          <Paper sx={{ p: 3 }}>
            <Typography variant='h6' gutterBottom>
              Specifications
            </Typography>
            <Grid container spacing={2}>
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Typography variant='body2' color='text.secondary'>
                  Make
                </Typography>
                <Typography variant='body1'>{car.make}</Typography>
              </Grid>
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Typography variant='body2' color='text.secondary'>
                  Model
                </Typography>
                <Typography variant='body1'>{car.model}</Typography>
              </Grid>
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Typography variant='body2' color='text.secondary'>
                  Year
                </Typography>
                <Typography variant='body1'>{car.year}</Typography>
              </Grid>
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Typography variant='body2' color='text.secondary'>
                  Mileage
                </Typography>
                <Typography variant='body1'>{car.mileage.toLocaleString()} miles</Typography>
              </Grid>
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Typography variant='body2' color='text.secondary'>
                  Engine Size
                </Typography>
                <Typography variant='body1'>{car.engineSize}</Typography>
              </Grid>
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Typography variant='body2' color='text.secondary'>
                  Doors
                </Typography>
                <Typography variant='body1'>{car.doors}</Typography>
              </Grid>
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Typography variant='body2' color='text.secondary'>
                  Price
                </Typography>
                <Typography variant='body1'>${car.price.toLocaleString()}</Typography>
              </Grid>
              <Grid size={{ xs: 12, sm: 6, md: 3 }}>
                <Typography variant='body2' color='text.secondary'>
                  Status
                </Typography>
                <Chip label={car.inStock ? 'In Stock' : 'Out of Stock'} color={car.inStock ? 'success' : 'error'} size='small' />
              </Grid>
            </Grid>
          </Paper>
        </Grid>

        {/* Features */}
        <Grid size={{ xs: 12 }}>
          <Paper sx={{ p: 3 }}>
            <Typography variant='h6' gutterBottom>
              Features
            </Typography>
            <Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 1 }}>
              {(car.features || []).map((feature: string, index: number) => (
                <Chip key={index} label={feature} variant='outlined' />
              ))}
            </Box>
          </Paper>
        </Grid>

        {/* Description */}
        <Grid size={{ xs: 12 }}>
          <Paper sx={{ p: 3 }}>
            <Typography variant='h6' gutterBottom>
              Description
            </Typography>
            <Typography variant='body1'>{car.description}</Typography>
          </Paper>
        </Grid>
      </Grid>
    </Container>
  );
};

export default CarDetail;
