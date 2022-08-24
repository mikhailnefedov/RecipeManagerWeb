import Button from '@mui/material/Button';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import { Link } from 'react-router-dom';

export const Header = () => {
  return (
    <Toolbar sx={{ borderBottom: 2, borderColor: 'divider' }}>
      <Link to="">
        <Button variant="outlined">Recipe Manager Web</Button>
      </Link>
    </Toolbar>
  );
};
