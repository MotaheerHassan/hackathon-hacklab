import React, { useState } from "react";

const Login = () => {

  const [empId,setEmpId] = useState('')

  const handleSubmit = (e) =>{
    e.preventDefault()
    console.log(empId)
  }


  return (
    <div className="auth-form-container">
      <form onSubmit={handleSubmit} className="login-form">
        <label htmlFor="empId">Enter Employee ID</label>
        <input type="text" value={empId}  onChange={(e) => setEmpId(e.target.value)} name="empId" id="empId" placeholder="Employee Id"/>
        <button type="submit">Log In</button>
      </form>
    </div>
  );
};

export default Login;
