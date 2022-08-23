import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import { Header } from './Header';
import { HomePage } from './HomePage';

export default function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <Header></Header>
      </div>
      <Routes>
        <Route path="" element={<HomePage />}></Route>
      </Routes>
    </BrowserRouter>
  );
}
