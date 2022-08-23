/** @jsxImportSource @emotion/react */
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import { Link } from 'react-router-dom';
import { css } from '@emotion/react';

export const HomePage = () => (
  <div>
    <Grid container spacing={2}>
      <Grid item xs={6}>
        <Link
          to=""
          css={css`
            text-decoration: none;
          `}
        >
          <Box sx={{ minHeight: 100 }}>
            <Card variant="outlined">
              <Typography>Rezepte</Typography>
            </Card>
          </Box>
        </Link>
      </Grid>
      <Grid item xs={6}>
        <div>xs=6</div>
      </Grid>
      <Grid item xs={4}>
        <div>xs=4</div>
      </Grid>
      <Grid item xs={4}>
        <div>xs=4</div>
      </Grid>
      <Grid item xs={4}>
        <div>xs=4</div>
      </Grid>
    </Grid>
  </div>
);
