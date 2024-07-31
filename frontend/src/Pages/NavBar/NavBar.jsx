import React, { useEffect, useState } from 'react'
import './navbar.css'
import Logo from '../../Assets/Logo-small.svg'
import { parseJwt } from '../../global/Global';

const NavBar = () => {
  const [loggedIn, setLoggedIn] = useState(false);  
  useEffect(()=>{ 
    if (localStorage.getItem("token") !== null) {
      const token = localStorage.getItem("token");
      const parsedToken = parseJwt(token);  
      const currentTime = new Date().getTime();
      if (parsedToken.exp * 1000 < currentTime) {
        localStorage.removeItem("token");
        setLoggedIn(false);
      }
      setLoggedIn(true);
    }
    else{
      setLoggedIn(false); 
      const path = (window.location.href.split('/'))[3]; 
      const exceptPaths = ['login','register','employee', 'menu',''];
      if(!exceptPaths.includes(path)){
        window.location.href = '/login';
      }


      window.location.href = '/login';
    }
  },[])
  
  return (
    <nav>
      <div className="left">
        <a href='/'><img src={Logo} alt="" /></a>
      </div>
      <div className="right">
        <ul>
          <li><a href="/menu">Menu</a></li>
          <li><a href="/store">Find a store</a></li> 
          {
            loggedIn ? <li><a href="#">Cart</a></li> : <>
              <li><a href='/login'>Login</a></li>
              <li><a href='/register'>Register</a></li>
            </>
          }
        </ul>
      </div>
    </nav>
  )
}

export default NavBar