import React from "react";
import "./login.css";

const Login = () => {
  return (
    <div className="login-page">
      <div className="signin-container">
        <h1>Sign In to Planetbucks</h1>
        <form>
          <input
            type="text"
            id="username"
            name="username"
            placeholder="email address"
            required
          />
          <input
            type="password"
            id="password"
            name="password"
            placeholder="password"
            required
          />
          <button type="submit">Sign In</button>
          <a href="#">New? Register Here</a>
        </form>
      </div>
    </div>
  );
};

export default Login;
