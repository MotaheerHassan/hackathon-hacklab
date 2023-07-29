import React, { useState } from "react";


const AddProjectDetails = () => {
  const [projectName, setProjectName] = useState("");
  const [projectDesc, setProjectDesc] = useState("");
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [achievements, setAchievements] = useState("");
  const [skills, setSkills] = useState("");
  const [role, setRole] = useState("");

  const handleProjectDetailsSubmit = () =>{
    
  }

  return (
    <div className="auth-form-container">
      <form
        className="project-details-form"
        onSubmit={handleProjectDetailsSubmit}
      >
        <label htmlFor="projectName">Project Name</label>
        <input
          value={projectName}
          type="text"
          placeholder="Enter Project Name"
          id="projectName"
          name="projectName"
          onChange={(e) => setProjectName(e.target.value)}
        />
        <label htmlFor="projectDescription">Project Description</label>
        <input
          value={projectDesc}
          type="text"
          placeholder="Enter Project Description"
          id="projectDescription"
          name="projectDescription"
          onChange={(e) => setProjectDesc(e.target.value)}
        />
        <label htmlFor="startDate">Start Date</label>
        <input
          value={startDate}
          type="date"
          placeholder="Enter date"
          id="startDate"
          name="startDate"
          onChange={(e) => setStartDate(e.target.value)}
        />
        <label htmlFor="endDate">End Date</label>
        <input
          value={endDate}
          type="text"
          placeholder="Enter End Date"
          id="endDate"
          name="endDate"
          onChange={(e) => setEndDate(e.target.value)}
        />
        <label htmlFor="achievements">Achievements</label>
        <input
          value={achievements}
          type="text"
          placeholder="Enter Achievements"
          name="achievements"
          id="achievements"
          onChange={(e) => setAchievements(e.target.value)}
        />
        <label htmlFor="skills">Skills</label>
        <input
          value={skills}
          type="text"
          placeholder="Enter Skills"
          id="skills"
          name="skills"
          onChange={(e) => setSkills(e.target.value)}
        />
        <label htmlFor="role">Role</label>
        <input
          value={role}
          type="Enter Role"
          name="role"
          id="role"
          onChange={(e) => setRole(e.target.value)}
        />
        <button type="submit">Submit Project Details</button>
      </form>
    </div>
  );
};

export default AddProjectDetails;
