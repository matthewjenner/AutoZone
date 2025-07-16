import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../app/store';
import { submitPaperworkApplication } from '../../app/slices/paperworkFormSlice';
import { Container, Typography, TextField, Button, Box, Paper, Grid, Alert, Stepper, Step, StepLabel } from '@mui/material';
import { Send } from '@mui/icons-material';

const Paperwork: React.FC = () => {
  const dispatch = useDispatch();
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const { submitting, submitted, error } = useSelector((state: RootState) => state.paperworkForm as any);

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const formData = new FormData(event.currentTarget);

    const paperworkData = {
      firstName: formData.get('firstName') as string,
      lastName: formData.get('lastName') as string,
      email: formData.get('email') as string,
      phone: formData.get('phone') as string,
      address: formData.get('address') as string,
      city: formData.get('city') as string,
      state: formData.get('state') as string,
      zipCode: formData.get('zipCode') as string,
      driverLicense: formData.get('licenseNumber') as string,
      ssn: formData.get('ssn') as string,
      employment: formData.get('employer') as string,
      income: formData.get('income') as string,
      downPayment: formData.get('downPayment') as string,
      tradeIn: formData.get('tradeInValue') as string,
    };

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    dispatch(submitPaperworkApplication(paperworkData) as any);
  };

  const steps = ['Personal Information', 'Financial Information', 'Vehicle Details', 'Review & Submit'];

  return (
    <Container maxWidth='lg' sx={{ py: 4 }}>
      <Typography variant='h3' component='h1' gutterBottom align='center'>
        Purchase Paperwork
      </Typography>

      <Typography variant='h6' color='text.secondary' align='center' sx={{ mb: 6 }}>
        Complete your vehicle purchase application
      </Typography>

      {/* Progress Stepper */}
      <Box sx={{ mb: 6 }}>
        <Stepper activeStep={3} alternativeLabel>
          {steps.map(label => (
            <Step key={label}>
              <StepLabel>{label}</StepLabel>
            </Step>
          ))}
        </Stepper>
      </Box>

      <Paper sx={{ p: 4 }}>
        {submitted && (
          <Alert severity='success' sx={{ mb: 3 }}>
            Your application has been submitted successfully! We&apos;ll contact you within 24 hours.
          </Alert>
        )}

        {error && (
          <Alert severity='error' sx={{ mb: 3 }}>
            {error}
          </Alert>
        )}

        <Box component='form' onSubmit={handleSubmit}>
          <Grid container spacing={3}>
            {/* Personal Information */}
            <Grid size={{ xs: 12 }}>
              <Typography variant='h5' gutterBottom sx={{ mb: 3 }}>
                Personal Information
              </Typography>
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField required fullWidth name='firstName' label='First Name' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField required fullWidth name='lastName' label='Last Name' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField required fullWidth name='email' label='Email Address' type='email' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField required fullWidth name='phone' label='Phone Number' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12 }}>
              <TextField required fullWidth name='address' label='Street Address' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 4 }}>
              <TextField required fullWidth name='city' label='City' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 4 }}>
              <TextField required fullWidth name='state' label='State' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 4 }}>
              <TextField required fullWidth name='zipCode' label='ZIP Code' variant='outlined' />
            </Grid>

            {/* Financial Information */}
            <Grid size={{ xs: 12 }}>
              <Typography variant='h5' gutterBottom sx={{ mb: 3, mt: 4 }}>
                Financial Information
              </Typography>
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField required fullWidth name='licenseNumber' label="Driver's License Number" variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField required fullWidth name='ssn' label='Social Security Number' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField required fullWidth name='income' label='Annual Income' type='number' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField required fullWidth name='employer' label='Employer' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField required fullWidth name='employmentLength' label='Length of Employment (years)' type='number' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField fullWidth name='downPayment' label='Down Payment Amount' type='number' variant='outlined' />
            </Grid>

            <Grid size={{ xs: 12, sm: 6 }}>
              <TextField fullWidth name='tradeInValue' label='Trade-in Value (if applicable)' type='number' variant='outlined' />
            </Grid>

            {/* Additional Notes */}
            <Grid size={{ xs: 12 }}>
              <Typography variant='h5' gutterBottom sx={{ mb: 3, mt: 4 }}>
                Additional Information
              </Typography>
            </Grid>

            <Grid size={{ xs: 12 }}>
              <TextField fullWidth name='additionalNotes' label='Additional Notes or Special Requests' multiline rows={4} variant='outlined' />
            </Grid>

            {/* Submit Button */}
            <Grid size={{ xs: 12 }}>
              <Box sx={{ display: 'flex', justifyContent: 'center', mt: 4 }}>
                <Button type='submit' variant='contained' size='large' startIcon={<Send />} disabled={submitting} sx={{ minWidth: 200 }}>
                  {submitting ? 'Submitting...' : 'Submit Application'}
                </Button>
              </Box>
            </Grid>
          </Grid>
        </Box>
      </Paper>
    </Container>
  );
};

export default Paperwork;
