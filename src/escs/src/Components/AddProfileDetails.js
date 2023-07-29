import React, { useState } from "react";

const AddDetails = () => {
  const [name, setName] = useState("");
  const [employeeId, setEmployeeId] = useState("");
  const [email, setEmail] = useState("");
  const [gender, setGender] = useState("");
  const [designation, setDesignation] = useState("");
  const [yoe, setYoe] = useState("");
  const [ttwo, setTtwo] = useState("");
  const [aoi, setAoi] = useState("");

  const handleProfileDetailsSubmit = () => {
    
  };

  return (
    <div className="auth-form-container">
      <form className="addDetailsForm" onSubmit={handleProfileDetailsSubmit}>
        <label htmlFor="name">Name</label>
        <input
          value={name}
          type="text"
          placeholder="Enter Name"
          id="name"
          name="name"
          onChange={(e) => setName(e.target.value)}
        />
        <label htmlFor="empId">Employee Id</label>
        <input
          value={employeeId}
          type="text"
          placeholder="Enter Employee Id"
          id="empId"
          name="empId"
          onChange={(e) => setEmployeeId(e.target.value)}
        />
        <label>Email Id</label>
        <input
          value={email}
          type="email"
          placeholder="Enter Email"
          id="email"
          name="email"
          onChange={(e) => setEmail(e.target.value)}
        />
        <label>Gender</label>
        <input
          value={gender}
          type="text"
          placeholder="Enter Gender"
          id="gender"
          name="gender"
          onChange={(e) => setGender(e.target.value)}
        />
        <label htmlFor="currDesg">Current Designation</label>
        <input
          value={designation}
          type="text"
          placeholder="Enter Current Designation"
          name="currDesg"
          onChange={(e) => setDesignation(e.target.value)}
        />
        <label>Years Of Experience</label>
        <input
          value={yoe}
          type="text"
          placeholder="Enter Years of Experience"
          onChange={(e) => setYoe(e.target.value)}
        />
        <label htmlFor="ttwo">Tech/Tools Worked on</label>
        <input
          value={ttwo}
          type="Enter Tools/ Technology Names"
          name="ttwo"
          id="ttwo"
          onChange={(e) => setTtwo(e.target.value)}
        />
        <label htmlFor="aoi">
          Area of Intrest (or Tech stack want to work on)
        </label>
        <input
          value={aoi}
          type="text"
          placeholder="Enter Area of Intrest"
          id="aoi"
          name="aoi"
          onChange={(e) => setAoi(e.target.value)}
        />
        <button type="submit">Submit Profile Details</button>
      </form>
    </div>
  );
};

export default AddDetails;
