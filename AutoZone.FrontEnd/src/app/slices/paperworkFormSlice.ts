import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import { paperworkApi } from '../../services/apiService';

interface PaperworkFormState {
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  address: string;
  city: string;
  state: string;
  zipCode: string;
  driverLicense: string;
  ssn: string;
  employment: string;
  income: string;
  downPayment: string;
  tradeIn: string;
  submitting: boolean;
  submitted: boolean;
  error: string | null;
}

const initialState: PaperworkFormState = {
  firstName: '',
  lastName: '',
  email: '',
  phone: '',
  address: '',
  city: '',
  state: '',
  zipCode: '',
  driverLicense: '',
  ssn: '',
  employment: '',
  income: '',
  downPayment: '',
  tradeIn: '',
  submitting: false,
  submitted: false,
  error: null,
};

export const submitPaperworkApplication = createAsyncThunk('paperworkForm/submitPaperworkApplication', async (applicationData: Omit<PaperworkFormState, 'submitting' | 'submitted' | 'error'>) => {
  try {
    await paperworkApi.submitApplication(applicationData);
  } catch (error: unknown) {
    let message = 'Failed to submit application';
    if (
      error &&
      typeof error === 'object' &&
      'response' in error &&
      error.response &&
      typeof error.response === 'object' &&
      'data' in error.response &&
      error.response.data &&
      typeof error.response.data === 'object' &&
      'message' in error.response.data
    ) {
      message = (error.response.data as { message?: string }).message || message;
    } else if (error instanceof Error) {
      message = error.message;
    }
    throw new Error(message);
  }
});

const paperworkFormSlice = createSlice({
  name: 'paperworkForm',
  initialState,
  reducers: {
    updateField: (state, action: PayloadAction<{ field: keyof PaperworkFormState; value: string }>) => {
      const { field, value } = action.payload;
      if (typeof state[field] === 'string') {
        (state[field] as string) = value;
      }
    },
    resetForm: state => {
      state.firstName = '';
      state.lastName = '';
      state.email = '';
      state.phone = '';
      state.address = '';
      state.city = '';
      state.state = '';
      state.zipCode = '';
      state.driverLicense = '';
      state.ssn = '';
      state.employment = '';
      state.income = '';
      state.downPayment = '';
      state.tradeIn = '';
      state.submitted = false;
      state.error = null;
    },
  },
  extraReducers: builder => {
    builder
      .addCase(submitPaperworkApplication.pending, state => {
        state.submitting = true;
        state.error = null;
      })
      .addCase(submitPaperworkApplication.fulfilled, state => {
        state.submitting = false;
        state.submitted = true;
      })
      .addCase(submitPaperworkApplication.rejected, (state, action) => {
        state.submitting = false;
        state.error = action.error.message || 'Failed to submit application';
      });
  },
});

export const { updateField, resetForm } = paperworkFormSlice.actions;
export default paperworkFormSlice.reducer;
