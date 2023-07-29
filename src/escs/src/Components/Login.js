import React, { useState } from "react";
import Welcome from "./Welcome";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [empId, setEmpId] = useState("");
  const history = useNavigate();


  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(empId);
  };
  
  const callLandingPage = () => {
    history("./Welcome");
  };

  return (
    <div className="auth-form-container">
      <form onSubmit={handleSubmit} className="login-form">
        <label htmlFor="empId">Enter Employee ID</label>
        <input
          type="text"
          value={empId}
          onChange={(e) => setEmpId(e.target.value)}
          name="empId"
          id="empId"
          placeholder="Employee Id"
        />
        <button type="submit" onClick={callLandingPage}>
          Log In
        </button>
      </form>
    </div>
  );
};

export default Login;
