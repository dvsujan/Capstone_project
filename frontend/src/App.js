import logo from './logo.svg';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import './App.css';
import Login from './Pages/Login/Login';
import NavBar from './Pages/NavBar/NavBar';
import Register from './Pages/Register/Register';
import LandingPage from './Pages/Landing/Landing';
import Menu from './Pages/Menu/Menu';
import Product from './Pages/Product/Product'; 
import Store from './Pages/Store/Store';
import Cart from './Pages/Cart/Cart';
function App() {
  return (
    <>
     <Router>
          <NavBar />
          <Routes>
            <Route path="/" element={<LandingPage />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/menu" element={<Menu/>} />
            <Route path="/product/*" element={<Product/>} />
            <Route path="/store" element={<Store/>} />
            <Route path="/cart" element={<Cart/>} />
            <Route path="*" element={<div>404 Not Found</div>} />
          </Routes>
        </Router>
    </>
  );
}

export default App;
