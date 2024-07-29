import React, {useRef , useEffect , useState}from "react";
import "./login.css";
import toast , {Toaster} from "react-hot-toast";
import axios from "axios";

const Login = () => {  
  const usernameRef = useRef();
  const passwordRef = useRef();
  const isValidEmail = (email)=>{  
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  }

  const handleLogin = (e) => {
    e.preventDefault();
    const enteredUsername = usernameRef.current.value;
    const enteredPassword = passwordRef.current.value; 
    if(!isValidEmail(enteredUsername)){ 
      toast.error("Invalid email format");
      return;
    } 
    axios.post("http://localhost:12150/api/User/login", { 
      email: enteredUsername,
      password: enteredPassword,
    }).then((response)=>{
      if(response.status === 200){
        toast.success("Login successful");
        localStorage.setItem("token", response.data.token);
        window.location.href = "/menu";
      }else{
        toast.error(response.message);
      }
    }).catch((error)=>{
      toast.error("Invalid credentials");
    }) 
    
  };

  return (
    <div className="login-page">
      <div className="signin-container">
        <h1>Sign In to Planetbucks</h1>
        <form>
          <input
            type="text"
            id="username"
            name="username"
            placeholder="Email address"
            required
            ref={usernameRef}
          />
          <input
            type="password"
            id="password"
            name="password"
            placeholder="password"
            required
            ref={passwordRef}
          />
          <button onClick={handleLogin}>Sign In</button>
          <a href="#">New? Join Here</a>
        </form>
      </div> 
      <Toaster/>
    </div>
  );
};

export default Login;