import { configureStore } from '@reduxjs/toolkit';
import inventoryReducer from './slices/inventorySlice';
import selectedCarReducer from './slices/selectedCarSlice';
import contactFormReducer from './slices/contactFormSlice';
import paperworkFormReducer from './slices/paperworkFormSlice';

export const store = configureStore({
  reducer: {
    inventory: inventoryReducer,
    selectedCar: selectedCarReducer,
    contactForm: contactFormReducer,
    paperworkForm: paperworkFormReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
