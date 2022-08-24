/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import { maxHeight } from '@mui/system';
import { Link } from 'react-router-dom';
import LinkCard from './LinkCard';

export const HomePage = () => (
  <div>
    <Grid container spacing={2}>
      <Grid item xs={6}>
        <LinkCard linkTo="/" title="Rezepte"></LinkCard>
      </Grid>
      <Grid item xs={6} sx={{ height: '50%' }}>
        <LinkCard linkTo="/" title="Einkaufsliste"></LinkCard>
      </Grid>
      <Grid item xs={4}>
        <LinkCard
          linkTo="/recipecategories"
          title="Rezeptkategorien"
        ></LinkCard>
      </Grid>
      <Grid item xs={4}>
        <LinkCard linkTo="/" title="Lebensmittel"></LinkCard>
      </Grid>
      <Grid item xs={4}>
        <LinkCard linkTo="/" title="Lebensmittelkategorien"></LinkCard>
      </Grid>
    </Grid>
  </div>
);
