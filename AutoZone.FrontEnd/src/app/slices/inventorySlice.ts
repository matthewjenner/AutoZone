import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import { inventoryApi } from '../../services/apiService';

export interface Car {
  id: string;
  make: string;
  model: string;
  year: number;
  price: number;
  mileage: number;
  images: string[];
  features: string[];
  description: string;
  engineSize: string;
  doors: number;
  inStock: boolean;
  isNewArrival: boolean;
}

interface InventoryState {
  cars: Car[];
  loading: boolean;
  error: string | null;
  filters: {
    make: string;
    model: string;
    yearMin: number;
    yearMax: number;
    priceMin: number;
    priceMax: number;
    engineSize: string;
    doors: string;
    inStockOnly: boolean;
    newArrivals: boolean;
    features: string[];
  };
}

const initialState: InventoryState = {
  cars: [],
  loading: false,
  error: null,
  filters: {
    make: '',
    model: '',
    yearMin: 1990,
    yearMax: 2024,
    priceMin: 0,
    priceMax: 100000,
    engineSize: '',
    doors: '',
    inStockOnly: false,
    newArrivals: false,
    features: [],
  },
};

export const fetchCars = createAsyncThunk('inventory/fetchCars', async (filters?: Partial<InventoryState['filters']>) => {
  try {
    const cars = await inventoryApi.getCars(filters);
    return cars;
  } catch (error: unknown) {
    let message = 'Failed to fetch cars';
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

export const fetchCarById = createAsyncThunk('inventory/fetchCarById', async (id: string) => {
  try {
    const car = await inventoryApi.getCarById(id);
    return car;
  } catch (error: unknown) {
    let message = 'Failed to fetch car';
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

export const searchCars = createAsyncThunk('inventory/searchCars', async (query: string) => {
  try {
    const cars = await inventoryApi.searchCars(query);
    return cars;
  } catch (error: unknown) {
    let message = 'Failed to search cars';
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

const inventorySlice = createSlice({
  name: 'inventory',
  initialState,
  reducers: {
    setFilters: (state, action: PayloadAction<Partial<InventoryState['filters']>>) => {
      state.filters = { ...state.filters, ...action.payload };
    },
    clearFilters: state => {
      state.filters = initialState.filters;
    },
  },
  extraReducers: builder => {
    builder
      .addCase(fetchCars.pending, state => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchCars.fulfilled, (state, action) => {
        state.loading = false;
        state.cars = action.payload;
      })
      .addCase(fetchCars.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'Failed to fetch cars';
      })
      .addCase(fetchCarById.pending, state => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchCarById.fulfilled, (state, action) => {
        state.loading = false;
        // Update the car in the list or add it if not present
        const index = state.cars.findIndex(car => car.id === action.payload.id);
        if (index !== -1) {
          state.cars[index] = action.payload;
        } else {
          state.cars.push(action.payload);
        }
      })
      .addCase(fetchCarById.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'Failed to fetch car';
      })
      .addCase(searchCars.pending, state => {
        state.loading = true;
        state.error = null;
      })
      .addCase(searchCars.fulfilled, (state, action) => {
        state.loading = false;
        state.cars = action.payload;
      })
      .addCase(searchCars.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'Failed to search cars';
      });
  },
});

export const { setFilters, clearFilters } = inventorySlice.actions;
export default inventorySlice.reducer;
