import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import HomePage from './Pages/HomePage';
import ProfilePage from './Pages/ProfilePage';
import LoginPage from './Pages/LoginPage';
import RegistrationPage from './Pages/RegistrationPage';
import RecepySetPage from './Pages/RecepySetPage'
import RecepyForm from './Pages/RecepyFormPage'
import RecepyInSetPage from './Pages/RecepyInSetPage'

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <BrowserRouter>
  <React.StrictMode>
  <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/recepy/new" element={<RecepyForm />} />
        <Route path="/recepyset" element={<RecepySetPage />} />
        <Route path="/recepyset/:id" element={<RecepyInSetPage />} />
        <Route path="/profile" element={<ProfilePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegistrationPage />} />
      </Routes>
  </React.StrictMode>
  </BrowserRouter>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
