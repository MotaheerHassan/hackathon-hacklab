import React, { useState } from "react";
import './Welcome.css'
import { useNavigate } from "react-router";
const Welcome = (props) => {

  const navigate = useNavigate();

  const profileDetails =  props.profileDetails ||  {
    Name: 'Kundan Kumar',
    EmployeId: 1630,
    EmailId: 'kundan.kumar@talentica.com',
    Gender: 'Male',
    Designation:"Software Engineer",
    YOE: '3 Years',
    Skills:"Java, React, JS, Node, .Net",
    Interest:'Machine Learning, Artificial Intelligence',
    Others: ""
  };

  const projectsDetails = props.projectDetails || [
     {
      ProjectName: "Employee Self Care System",
      Description: "social coding event that brings computer programmers and other interested people together to improve upon or build a new software program.",
      Role:"Software Engineer",
      Achivements: 'Nothing so far',
      TechUsed: "Java, React, JS, Node, .Net",
      Duration: "1 Year",
      ProblemsSolved:"Implemented the analytics in the project"
     },
      {
      ProjectName: "Employee Self Care System2",
      Description: "social coding event that brings computer programmers and other interested people together to improve upon or build a new software program.",
      Role:"Software Engineer",
      Achivements: 'Nothing so far',
      TechUsed: "Java, React, JS, Node, .Net",
      Duration: "1 Year",
      ProblemsSolved:"Implemented the analytics in the project"
     }

    ]

    const navigateAddDetailsPage = () =>{
      navigate('/adddetails')
    }

    const navigateAddProjectDetailsPage = () =>{
      navigate('/addprojectdetails')
    }

 const showprojectDetails = (projectDetails) =>{
  let ele = [];
  for (let i =0; i< projectDetails.length; i++){
    ele.push(<div className="project-card">
        
        <p><strong>ProjectName:</strong> {projectsDetails[i].ProjectName}</p>
        <p><strong>Description:</strong> {projectsDetails[i].Description}</p>
        <p><strong>Role:</strong> {projectsDetails[i].Role}</p>
        <p><strong>Achivements:</strong> {projectsDetails[i].Achivements}</p>
        <p><strong>TechUsed:</strong> {projectsDetails[i].TechUsed}</p>
        <p><strong>Duration:</strong> {projectsDetails[i].Duration}</p>
        <p><strong>ProblemsSolved:</strong> {projectsDetails[i].ProblemsSolved}</p>
        <button onClick={navigateAddProjectDetailsPage}>Edit Project Details </button>
      </div>)
  }
  return ele
 } 
const divs = showprojectDetails(projectsDetails);

  return (
    <div className="Container">
      <div className="profile-container">
      <div className="profile-card">
        <h2>Profile Details:</h2>
        <p><strong>Name:</strong> {profileDetails.Name}</p>
        <p><strong>Employee Id:</strong> {profileDetails.EmployeId}</p>
        <p><strong>Email:</strong> {profileDetails.EmailId}</p>
        <p><strong>Gender:</strong> {profileDetails.Gender}</p>
        <p><strong>Designation:</strong> {profileDetails.Designation}</p>
        <p><strong>YOE:</strong> {profileDetails.YOE}</p>
        <p><strong>Skills:</strong> {profileDetails.Skills}</p>
        <p><strong>Interests:</strong> {profileDetails.Interest}</p>
        <p><strong>Others:</strong> {profileDetails.Others}</p>
        <button onClick={navigateAddDetailsPage}>Edit Profile</button>
      </div>
    </div>
    <div className="separator"><p>Projects:</p></div>
    <div className="ProjectDetails">
      <div className="EditProjectDetails">
          <div className="project-container">
          
              {
                divs
             }
    </div>
    </div>
    </div>
    </div>
  );
};

export default Welcome;
