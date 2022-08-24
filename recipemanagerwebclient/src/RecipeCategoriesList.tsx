import {
  CircularProgress,
  Dialog,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
} from '@mui/material';
import Button from '@mui/material/Button';
import React, { useEffect, useState } from 'react';

export default function RecipeCategoriesList() {
  const [recipeCategories, setRecipeCategories] = useState<RecipeCategory[]>(
    []
  );
  const [isLoading, setIsLoading] = useState(false);
  function loadData() {
    setIsLoading(true);
    const getData = async () => {
      const response = await fetch(
        'https://localhost:7287/api/recipecategories'
      );
      setRecipeCategories(await response.json());
    };
    getData();
    setIsLoading(false);
  }

  useEffect(() => {
    loadData();
  }, []);

  return (
    <React.Fragment>
      <Typography component="h2" variant="h6" color="primary" gutterBottom>
        Rezeptkategorien
      </Typography>
      <Table size="small">
        <TableHead>
          {isLoading ? (
            <CircularProgress />
          ) : (
            recipeCategories.map((e, i) => (
              <TableRow key={e.id}>
                <TableCell>{e.abbreviation}</TableCell>
                <TableCell>{e.name}</TableCell>
                <TableCell>
                  <Button onClick={() => deleteRecipeCategory(e.id)}>
                    Delete
                  </Button>
                </TableCell>
              </TableRow>
            ))
          )}
        </TableHead>
        <TableBody></TableBody>
      </Table>
    </React.Fragment>
  );

  async function deleteRecipeCategory(id: number) {
    const response = await fetch(
      'https://localhost:7287/api/recipecategories/' + id,
      {
        method: 'DELETE',
      }
    );
    var deleteSuccess = await response.json();
    if (deleteSuccess) {
      loadData();
    }
  }
}

interface RecipeCategory {
  id: number;
  abbreviation: string;
  name: string;
}
