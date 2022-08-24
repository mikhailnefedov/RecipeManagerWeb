/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import { Box, Card, Typography } from '@mui/material';
import { Link } from 'react-router-dom';

export default function LinkCard({ title, linkTo }: LinkCardProps) {
  return (
    <Link
      to={linkTo}
      css={css`
        text-decoration: none;
      `}
    >
      <Box sx={{ minHeight: 100 }}>
        <Card variant="outlined">
          <Typography variant="h3" align="center">
            {title}
          </Typography>
        </Card>
      </Box>
    </Link>
  );
}

type LinkCardProps = {
  title: string;
  linkTo: string;
};
