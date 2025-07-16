import React, { useState } from 'react';
import { Box, IconButton, Paper, useTheme, useMediaQuery } from '@mui/material';
import { ChevronLeft, ChevronRight } from '@mui/icons-material';

interface CarouselProps {
  images: string[];
  alt: string;
}

const Carousel: React.FC<CarouselProps> = ({ images, alt }) => {
  const [currentIndex, setCurrentIndex] = useState(0);
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down('md'));

  const handlePrevious = () => {
    setCurrentIndex(prevIndex => (prevIndex === 0 ? images.length - 1 : prevIndex - 1));
  };

  const handleNext = () => {
    setCurrentIndex(prevIndex => (prevIndex === images.length - 1 ? 0 : prevIndex + 1));
  };

  const handleDotClick = (index: number) => {
    setCurrentIndex(index);
  };

  return (
    <Box sx={{ position: 'relative', width: '100%' }}>
      <Paper
        elevation={3}
        sx={{
          position: 'relative',
          overflow: 'hidden',
          borderRadius: 2,
        }}>
        <Box
          component='img'
          src={images[currentIndex]}
          alt={`${alt} - Image ${currentIndex + 1}`}
          sx={{
            width: '100%',
            height: isMobile ? 300 : 500,
            objectFit: 'cover',
            display: 'block',
          }}
        />

        {images.length > 1 && (
          <>
            <IconButton
              onClick={handlePrevious}
              sx={{
                position: 'absolute',
                left: 8,
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
                right: 8,
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

            <Box
              sx={{
                position: 'absolute',
                bottom: 16,
                left: '50%',
                transform: 'translateX(-50%)',
                display: 'flex',
                gap: 1,
              }}>
              {images.map((_, index) => (
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
          </>
        )}
      </Paper>
    </Box>
  );
};

export default Carousel;
