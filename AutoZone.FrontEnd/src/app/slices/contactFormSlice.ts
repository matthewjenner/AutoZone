import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { contactApi } from '../../services/apiService';

interface ContactFormState {
  name: string;
  email: string;
  phone: string;
  message: string;
  submitting: boolean;
  submitted: boolean;
  error: string | null;
}

const initialState: ContactFormState = {
  name: '',
  email: '',
  phone: '',
  message: '',
  submitting: false,
  submitted: false,
  error: null,
};

export const submitContactForm = createAsyncThunk('contactForm/submitContactForm', async (formData: { name: string; email: string; phone: string; message: string }) => {
  try {
    await contactApi.submitContact(formData);
  } catch (error: unknown) {
    let message = 'Failed to submit contact form';
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

const contactFormSlice = createSlice({
  name: 'contactForm',
  initialState,
  reducers: {
    setContactFormField: (state, action: { payload: { field: keyof ContactFormState; value: string } }) => {
      // Only allow updating string fields
      const { field, value } = action.payload;
      if (typeof state[field] === 'string') {
        (state[field] as string) = value;
      }
    },
    resetForm: state => {
      state.name = '';
      state.email = '';
      state.phone = '';
      state.message = '';
      state.submitted = false;
      state.error = null;
    },
  },
  extraReducers: builder => {
    builder
      .addCase(submitContactForm.pending, state => {
        state.submitting = true;
        state.error = null;
      })
      .addCase(submitContactForm.fulfilled, state => {
        state.submitting = false;
        state.submitted = true;
      })
      .addCase(submitContactForm.rejected, (state, action) => {
        state.submitting = false;
        state.error = action.error.message || 'Failed to submit contact form';
      });
  },
});

export const { setContactFormField, resetForm } = contactFormSlice.actions;
export default contactFormSlice.reducer;
