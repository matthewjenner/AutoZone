import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router';
import Layout from './components/Layout';
import Home from './features/inventory/Home';
import CarDetail from './features/carDetail/CarDetail';
import Contact from './features/contact/Contact';
import About from './features/contact/About';
import Paperwork from './features/paperwork/Paperwork';

const App: React.FC = () => {
  return (
    <React.Fragment>
      <BrowserRouter>
        <Layout>
          {/* Upgrade this to newer router version and style */}
          <Routes>
            <Route path='/' element={<Home />} />
            <Route path='/cars/:id' element={<CarDetail />} />
            <Route path='/contact' element={<Contact />} />
            <Route path='/about' element={<About />} />
            <Route path='/paperwork/:id' element={<Paperwork />} />
          </Routes>
        </Layout>
      </BrowserRouter>
    </React.Fragment>
  );
};

export default App;
