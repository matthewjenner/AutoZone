import httpClient from './httpService';
import { Car } from '../app/slices/inventorySlice';

export interface ApiResponse<T> {
  data: T;
  message?: string;
  success: boolean;
}

export interface PaginatedResponse<T> {
  data: T[];
  total: number;
  page: number;
  pageSize: number;
  totalPages: number;
}

export interface VehicleFilters {
  make?: string;
  model?: string;
  yearMin?: number;
  yearMax?: number;
  priceMin?: number;
  priceMax?: number;
  engineSize?: string;
  doors?: string;
  inStockOnly?: boolean;
  newArrivals?: boolean;
}

export interface ContactFormData {
  name: string;
  email: string;
  phone: string;
  message: string;
}

export interface PaperworkApplicationData {
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
}

export interface UserRegistrationData {
  username: string;
  email: string;
  password: string;
  role: string;
}

export interface UserLoginData {
  email: string;
  password: string;
}

export interface UserProfile {
  id: string;
  username: string;
  email: string;
  role: string;
}

export interface ApplicationStatus {
  id: string;
  status: string;
  submittedAt: string;
  updatedAt: string;
}

export const inventoryApi = {
  getCars: async (filters?: VehicleFilters): Promise<Car[]> => {
    const response = await httpClient.get<Car[]>('/vehicles', { params: filters });
    return response.data;
  },

  getCarById: async (id: string): Promise<Car> => {
    const response = await httpClient.get<Car>(`/vehicles/${id}`);
    return response.data;
  },

  searchCars: async (query: string): Promise<Car[]> => {
    const response = await httpClient.get<Car[]>('/vehicles/search', { params: { q: query } });
    return response.data;
  },
};

export const contactApi = {
  submitContact: async (formData: ContactFormData): Promise<void> => {
    await httpClient.post<ApiResponse<void>>('/contact', formData);
  },
};

export const paperworkApi = {
  submitApplication: async (applicationData: PaperworkApplicationData): Promise<void> => {
    await httpClient.post<ApiResponse<void>>('/paperwork', applicationData);
  },

  getApplicationStatus: async (id: string): Promise<ApplicationStatus> => {
    const response = await httpClient.get<ApiResponse<ApplicationStatus>>(`/paperwork/${id}`);
    return response.data.data;
  },
};

export const userApi = {
  register: async (userData: UserRegistrationData): Promise<UserProfile> => {
    const response = await httpClient.post<ApiResponse<UserProfile>>('/users/register', userData);
    return response.data.data;
  },

  login: async (credentials: UserLoginData): Promise<UserProfile> => {
    const response = await httpClient.post<ApiResponse<UserProfile>>('/users/login', credentials);
    return response.data.data;
  },

  getProfile: async (): Promise<UserProfile> => {
    const response = await httpClient.get<ApiResponse<UserProfile>>('/users/profile');
    return response.data.data;
  },
};
