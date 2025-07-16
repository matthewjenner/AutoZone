import React, { useState, useEffect } from 'react';
import { Box, IconButton, useTheme, useMediaQuery } from '@mui/material';
import { ChevronLeft, ChevronRight } from '@mui/icons-material';

const carouselImages = [
  {
    url: 'https://picsum.photos/1920/600?random=hero1',
    alt: 'Luxury cars on display',
    title: 'Premium Selection',
    subtitle: 'Find your dream car from our extensive collection',
  },
  {
    url: 'https://picsum.photos/1920/600?random=hero2',
    alt: 'Sports cars lineup',
    title: 'Performance Vehicles',
    subtitle: 'Experience power and precision',
  },
  {
    url: 'https://picsum.photos/1920/600?random=hero3',
    alt: 'Family vehicles',
    title: 'Family Friendly',
    subtitle: 'Safe and reliable vehicles for your family',
  },
  {
    url: 'https://picsum.photos/1920/600?random=hero4',
    alt: 'SUV collection',
    title: 'Adventure Ready',
    subtitle: 'Explore the world with our SUV selection',
  },
  {
    url: 'https://picsum.photos/1920/600?random=hero5',
    alt: 'Electric vehicles',
    title: 'Future Forward',
    subtitle: 'Eco-friendly electric and hybrid options',
  },
];

const HeroCarousel: React.FC = () => {
  const [currentIndex, setCurrentIndex] = useState(0);
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down('md'));

  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentIndex(prevIndex => (prevIndex + 1) % carouselImages.length);
    }, 5000);

    return () => clearInterval(interval);
  }, []);

  const handlePrevious = () => {
    setCurrentIndex(prevIndex => (prevIndex === 0 ? carouselImages.length - 1 : prevIndex - 1));
  };

  const handleNext = () => {
    setCurrentIndex(prevIndex => (prevIndex === carouselImages.length - 1 ? 0 : prevIndex + 1));
  };

  const handleDotClick = (index: number) => {
    setCurrentIndex(index);
  };

  return (
    <Box sx={{ position: 'relative', width: '100%', height: isMobile ? 300 : 500 }}>
      <Box
        component='img'
        src={carouselImages[currentIndex].url}
        alt={carouselImages[currentIndex].alt}
        sx={{
          width: '100%',
          height: '100%',
          objectFit: 'cover',
          display: 'block',
        }}
      />

      {/* Overlay with text */}
      <Box
        sx={{
          position: 'absolute',
          top: 0,
          left: 0,
          right: 0,
          bottom: 0,
          background: 'linear-gradient(45deg, rgba(0,0,0,0.3) 0%, rgba(0,0,0,0.1) 100%)',
          display: 'flex',
          flexDirection: 'column',
          justifyContent: 'center',
          alignItems: 'center',
          color: 'white',
          textAlign: 'center',
          px: 4,
        }}>
        <Box
          sx={{
            fontSize: isMobile ? '2rem' : '3.5rem',
            fontWeight: 'bold',
            mb: 2,
            textShadow: '2px 2px 4px rgba(0,0,0,0.5)',
          }}>
          {carouselImages[currentIndex].title}
        </Box>
        <Box
          sx={{
            fontSize: isMobile ? '1rem' : '1.5rem',
            textShadow: '1px 1px 2px rgba(0,0,0,0.5)',
          }}>
          {carouselImages[currentIndex].subtitle}
        </Box>
      </Box>

      {/* Navigation arrows */}
      <IconButton
        onClick={handlePrevious}
        sx={{
          position: 'absolute',
          left: 16,
          top: '50%',
          transform: 'translateY(-50%)',
          bgcolor: 'rgba(0,0,0,0.5)',
          color: 'white',
          '&:hover': {
            bgcolor: 'rgba(0,0,0,0.7)',
          },
        }}>
        <ChevronLeft />
      </IconButton>

      <IconButton
        onClick={handleNext}
        sx={{
          position: 'absolute',
          right: 16,
          top: '50%',
          transform: 'translateY(-50%)',
          bgcolor: 'rgba(0,0,0,0.5)',
          color: 'white',
          '&:hover': {
            bgcolor: 'rgba(0,0,0,0.7)',
          },
        }}>
        <ChevronRight />
      </IconButton>

      {/* Dot indicators */}
      <Box
        sx={{
          position: 'absolute',
          bottom: 16,
          left: '50%',
          transform: 'translateX(-50%)',
          display: 'flex',
          gap: 1,
        }}>
        {carouselImages.map((_, index) => (
          <Box
            key={index}
            onClick={() => handleDotClick(index)}
            sx={{
              width: 12,
              height: 12,
              borderRadius: '50%',
              bgcolor: index === currentIndex ? 'primary.main' : 'rgba(255,255,255,0.5)',
              cursor: 'pointer',
              transition: 'background-color 0.2s',
              '&:hover': {
                bgcolor: index === currentIndex ? 'primary.main' : 'rgba(255,255,255,0.7)',
              },
            }}
          />
        ))}
      </Box>
    </Box>
  );
};

export default HeroCarousel;
