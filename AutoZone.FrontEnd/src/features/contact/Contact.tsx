import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../app/store';
import { submitContactForm } from '../../app/slices/contactFormSlice';
import { Container, Typography, TextField, Button, Box, Paper, Grid, Alert } from '@mui/material';
import { Send, Phone, Email, LocationOn } from '@mui/icons-material';

const Contact: React.FC = () => {
  const dispatch = useDispatch();
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const { submitting, submitted, error } = useSelector((state: RootState) => state.contactForm as any);

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const formData = new FormData(event.currentTarget);

    const contactData = {
      name: formData.get('name') as string,
      email: formData.get('email') as string,
      phone: formData.get('phone') as string,
      message: formData.get('message') as string,
    };

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    dispatch(submitContactForm(contactData) as any);
  };

  return (
    <Container maxWidth='lg' sx={{ py: 4 }}>
      <Typography variant='h3' component='h1' gutterBottom align='center'>
        Contact Us
      </Typography>

      <Typography variant='h6' color='text.secondary' align='center' sx={{ mb: 6 }}>
        Get in touch with our sales team
      </Typography>

      <Grid container spacing={6}>
        {/* Contact Form */}
        <Grid size={{ xs: 12, md: 8 }}>
          <Paper sx={{ p: 4 }}>
            <Typography variant='h5' gutterBottom>
              Send us a message
            </Typography>

            {submitted && (
              <Alert severity='success' sx={{ mb: 3 }}>
                Thank you for your message! We&apos;ll get back to you soon.
              </Alert>
            )}

            {error && (
              <Alert severity='error' sx={{ mb: 3 }}>
                {error}
              </Alert>
            )}

            <Box component='form' onSubmit={handleSubmit} sx={{ mt: 3 }}>
              <Grid container spacing={3}>
                <Grid size={{ xs: 12, sm: 6 }}>
                  <TextField required fullWidth name='name' label='Full Name' variant='outlined' />
                </Grid>
                <Grid size={{ xs: 12, sm: 6 }}>
                  <TextField required fullWidth name='email' label='Email Address' type='email' variant='outlined' />
                </Grid>
                <Grid size={{ xs: 12 }}>
                  <TextField fullWidth name='phone' label='Phone Number' variant='outlined' />
                </Grid>
                <Grid size={{ xs: 12 }}>
                  <TextField required fullWidth name='message' label='Message' multiline rows={6} variant='outlined' />
                </Grid>
                <Grid size={{ xs: 12 }}>
                  <Button type='submit' variant='contained' size='large' startIcon={<Send />} disabled={submitting} fullWidth>
                    {submitting ? 'Sending...' : 'Send Message'}
                  </Button>
                </Grid>
              </Grid>
            </Box>
          </Paper>
        </Grid>

        {/* Contact Information */}
        <Grid size={{ xs: 12, md: 4 }}>
          <Paper sx={{ p: 4, height: 'fit-content' }}>
            <Typography variant='h5' gutterBottom>
              Contact Information
            </Typography>

            <Box sx={{ mt: 3 }}>
              <Box sx={{ display: 'flex', alignItems: 'center', mb: 3 }}>
                <LocationOn sx={{ mr: 2, color: 'primary.main' }} />
                <Box>
                  <Typography variant='subtitle1' fontWeight='bold'>
                    Address
                  </Typography>
                  <Typography variant='body2' color='text.secondary'>
                    123 Main Street
                    <br />
                    Anytown, USA 12345
                  </Typography>
                </Box>
              </Box>

              <Box sx={{ display: 'flex', alignItems: 'center', mb: 3 }}>
                <Phone sx={{ mr: 2, color: 'primary.main' }} />
                <Box>
                  <Typography variant='subtitle1' fontWeight='bold'>
                    Phone
                  </Typography>
                  <Typography variant='body2' color='text.secondary'>
                    (555) 123-4567
                  </Typography>
                </Box>
              </Box>

              <Box sx={{ display: 'flex', alignItems: 'center', mb: 3 }}>
                <Email sx={{ mr: 2, color: 'primary.main' }} />
                <Box>
                  <Typography variant='subtitle1' fontWeight='bold'>
                    Email
                  </Typography>
                  <Typography variant='body2' color='text.secondary'>
                    sales@autozone.com
                  </Typography>
                </Box>
              </Box>
            </Box>

            <Box sx={{ mt: 4 }}>
              <Typography variant='h6' gutterBottom>
                Business Hours
              </Typography>
              <Typography variant='body2' color='text.secondary'>
                Monday - Friday: 9:00 AM - 8:00 PM
                <br />
                Saturday: 9:00 AM - 6:00 PM
                <br />
                Sunday: 10:00 AM - 5:00 PM
              </Typography>
            </Box>
          </Paper>
        </Grid>
      </Grid>
    </Container>
  );
};

export default Contact;
