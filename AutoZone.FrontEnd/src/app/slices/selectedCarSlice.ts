import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { Car } from './inventorySlice';

interface SelectedCarState {
  car: Car | null;
  loading: boolean;
  error: string | null;
}

const initialState: SelectedCarState = {
  car: null,
  loading: false,
  error: null,
};

const selectedCarSlice = createSlice({
  name: 'selectedCar',
  initialState,
  reducers: {
    setSelectedCar: (state, action: PayloadAction<Car>) => {
      state.car = action.payload;
      state.error = null;
    },
    clearSelectedCar: state => {
      state.car = null;
      state.error = null;
    },
    setLoading: (state, action: PayloadAction<boolean>) => {
      state.loading = action.payload;
    },
    setError: (state, action: PayloadAction<string>) => {
      state.error = action.payload;
    },
  },
});

export const { setSelectedCar, clearSelectedCar, setLoading, setError } = selectedCarSlice.actions;
export default selectedCarSlice.reducer;
