import React from 'react';
import { Box, Typography, Paper, Grid, Card, CardContent, Container } from '@mui/material';
import { LocationOn, Phone, Email, AccessTime, DirectionsCar, Star } from '@mui/icons-material';

const About: React.FC = () => {
  return (
    <Container maxWidth='lg' sx={{ py: 4 }}>
      <Box>
        <Typography variant='h3' component='h1' gutterBottom align='center'>
          About AutoZone
        </Typography>

        <Typography variant='body1' color='text.secondary' sx={{ mb: 4 }} align='center'>
          Your trusted partner in finding the perfect vehicle
        </Typography>

        {/* Hero Image */}
        <Box sx={{ mb: 4 }}>
          <img
            src='https://picsum.photos/1200/400?random=about'
            alt='AutoZone Dealership'
            style={{
              width: '100%',
              height: '400px',
              objectFit: 'cover',
              borderRadius: '8px',
            }}
          />
        </Box>

        <Grid container spacing={4}>
          <Grid size={{ xs: 12, md: 8 }}>
            <Paper sx={{ p: 4, mb: 4 }}>
              <Typography variant='h5' gutterBottom>
                Our Story
              </Typography>

              <Typography variant='body1' paragraph>
                AutoZone has been serving the community for over 25 years, providing quality vehicles and exceptional customer service. We pride ourselves on our extensive inventory of pre-owned
                vehicles, all thoroughly inspected and certified to meet our high standards.
              </Typography>

              <Typography variant='body1' paragraph>
                Our team of experienced professionals is dedicated to helping you find the perfect vehicle that fits your needs and budget. We believe in transparency, honesty, and building long-term
                relationships with our customers.
              </Typography>

              <Typography variant='body1'>
                Whether you&apos;re looking for a family sedan, a sporty coupe, or a reliable SUV, we have the vehicle for you. Visit our showroom today and experience the AutoZone difference.
              </Typography>
            </Paper>

            <Paper sx={{ p: 4 }}>
              <Typography variant='h5' gutterBottom>
                Why Choose AutoZone?
              </Typography>

              <Box
                sx={{
                  display: 'grid',
                  gridTemplateColumns: {
                    xs: '1fr',
                    sm: 'repeat(2, 1fr)',
                    md: 'repeat(2, 1fr)',
                  },
                  gap: 3,
                }}>
                <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
                  <DirectionsCar color='primary' sx={{ mr: 2 }} />
                  <Box>
                    <Typography variant='h6'>Quality Vehicles</Typography>
                    <Typography variant='body2' color='text.secondary'>
                      All vehicles undergo rigorous inspection
                    </Typography>
                  </Box>
                </Box>

                <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
                  <Star color='primary' sx={{ mr: 2 }} />
                  <Box>
                    <Typography variant='h6'>Expert Service</Typography>
                    <Typography variant='body2' color='text.secondary'>
                      Professional and knowledgeable staff
                    </Typography>
                  </Box>
                </Box>

                <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
                  <AccessTime color='primary' sx={{ mr: 2 }} />
                  <Box>
                    <Typography variant='h6'>Convenient Hours</Typography>
                    <Typography variant='body2' color='text.secondary'>
                      Extended hours for your convenience
                    </Typography>
                  </Box>
                </Box>

                <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
                  <Phone color='primary' sx={{ mr: 2 }} />
                  <Box>
                    <Typography variant='h6'>24/7 Support</Typography>
                    <Typography variant='body2' color='text.secondary'>
                      Always here when you need us
                    </Typography>
                  </Box>
                </Box>
              </Box>
            </Paper>
          </Grid>

          <Grid size={{ xs: 12, md: 4 }}>
            <Box
              sx={{
                display: 'grid',
                gridTemplateColumns: '1fr',
                gap: 3,
                height: 'fit-content',
              }}>
              <Paper sx={{ p: 3 }}>
                <Typography variant='h6' gutterBottom>
                  Contact Information
                </Typography>

                <Box sx={{ mb: 3 }}>
                  <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
                    <LocationOn color='primary' sx={{ mr: 2 }} />
                    <Box>
                      <Typography variant='body2' color='text.secondary'>
                        Address
                      </Typography>
                      <Typography variant='body1'>
                        123 Auto Street
                        <br />
                        Car City, CC 12345
                      </Typography>
                    </Box>
                  </Box>

                  <Box sx={{ display: 'flex', alignItems: 'center', mb: 2 }}>
                    <Phone color='primary' sx={{ mr: 2 }} />
                    <Box>
                      <Typography variant='body2' color='text.secondary'>
                        Phone
                      </Typography>
                      <Typography variant='body1'>(555) 123-4567</Typography>
                    </Box>
                  </Box>

                  <Box sx={{ display: 'flex', alignItems: 'center' }}>
                    <Email color='primary' sx={{ mr: 2 }} />
                    <Box>
                      <Typography variant='body2' color='text.secondary'>
                        Email
                      </Typography>
                      <Typography variant='body1'>info@autozone.com</Typography>
                    </Box>
                  </Box>
                </Box>

                <Typography variant='h6' gutterBottom>
                  Business Hours
                </Typography>

                <Typography variant='body2' color='text.secondary'>
                  Monday - Friday: 9:00 AM - 8:00 PM
                  <br />
                  Saturday: 9:00 AM - 6:00 PM
                  <br />
                  Sunday: 11:00 AM - 5:00 PM
                </Typography>
              </Paper>

              <Card>
                <CardContent>
                  <Typography variant='h6' gutterBottom>
                    Our Stats
                  </Typography>

                  <Box sx={{ textAlign: 'center' }}>
                    <Typography variant='h3' color='primary' gutterBottom>
                      25+
                    </Typography>
                    <Typography variant='body2' color='text.secondary'>
                      Years in Business
                    </Typography>
                  </Box>

                  <Box sx={{ textAlign: 'center', mt: 3 }}>
                    <Typography variant='h3' color='primary' gutterBottom>
                      1000+
                    </Typography>
                    <Typography variant='body2' color='text.secondary'>
                      Happy Customers
                    </Typography>
                  </Box>

                  <Box sx={{ textAlign: 'center', mt: 3 }}>
                    <Typography variant='h3' color='primary' gutterBottom>
                      500+
                    </Typography>
                    <Typography variant='body2' color='text.secondary'>
                      Vehicles Sold
                    </Typography>
                  </Box>
                </CardContent>
              </Card>
            </Box>
          </Grid>
        </Grid>
      </Box>
    </Container>
  );
};

export default About;
