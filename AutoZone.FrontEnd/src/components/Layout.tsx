import React from 'react';
import { AppBar, Toolbar, Typography, Button, Box, useTheme, useMediaQuery, IconButton, Drawer, List, ListItem, ListItemText } from '@mui/material';
import { Menu as MenuIcon } from '@mui/icons-material';
import { useNavigate } from 'react-router';
import { useState } from 'react';

interface LayoutProps {
  children: React.ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => {
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down('md'));
  const navigate = useNavigate();
  const [mobileOpen, setMobileOpen] = useState(false);

  const menuItems = [
    { text: 'About', path: '/about' },
    { text: 'Contact', path: '/contact' },
  ];

  const handleDrawerToggle = () => {
    setMobileOpen(!mobileOpen);
  };

  const handleNavigation = (path: string) => {
    navigate(path);
    if (isMobile) {
      setMobileOpen(false);
    }
  };

  const drawer = (
    <Box>
      <List>
        {menuItems.map(item => (
          <ListItem component='button' disableGutters key={item.text} onClick={() => handleNavigation(item.path)}>
            <ListItemText primary={item.text} />
          </ListItem>
        ))}
      </List>
    </Box>
  );

  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
      <AppBar position='static' elevation={0}>
        <Toolbar>
          <Typography
            variant='h6'
            component='button'
            onClick={() => handleNavigation('/')}
            sx={{ flexGrow: 1, fontWeight: 'bold', color: 'inherit', background: 'none', border: 'none', cursor: 'pointer', textAlign: 'left', p: 0 }}>
            AutoZone
          </Typography>

          {isMobile ? (
            <IconButton color='inherit' aria-label='open drawer' edge='start' onClick={handleDrawerToggle}>
              <MenuIcon />
            </IconButton>
          ) : (
            <Box sx={{ display: 'flex', gap: 2 }}>
              {menuItems.map(item => (
                <Button key={item.text} color='inherit' onClick={() => handleNavigation(item.path)}>
                  {item.text}
                </Button>
              ))}
            </Box>
          )}
        </Toolbar>
      </AppBar>

      <Drawer
        variant='temporary'
        anchor='right'
        open={mobileOpen}
        onClose={handleDrawerToggle}
        ModalProps={{
          keepMounted: true,
        }}
        sx={{
          display: { xs: 'block', md: 'none' },
          '& .MuiDrawer-paper': { boxSizing: 'border-box', width: 240 },
        }}>
        {drawer}
      </Drawer>

      <Box component='main' sx={{ flexGrow: 1 }}>
        {children}
      </Box>
    </Box>
  );
};

export default Layout;
