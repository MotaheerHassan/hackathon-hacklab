import ReactDOM from "react-dom/client";
import {  Routes, Route, useNavigate } from "react-router-dom";
import Login from "./Components/Login";
import Welcome from "./Components/Welcome";
import AddDetails from "./Components/AddProfileDetails";
import './App.css';
import AddProjectDetails from "./Components/AddProjectDetails";


function App() {
  const navigate = useNavigate();
  return (
      <div>
        <button onClick={() => navigate(-1)}>go back</button>
        <Routes>
          <Route exact path="/" element={<Login/>}/>
          <Route exact path="/welcome" element={<Welcome/>}/>
          <Route exact path="/adddetails" element={<AddDetails/>}/>
          <Route exact path="/addprojectdetails" element={<AddProjectDetails/>}/>
        </Routes>
      </div>
  );
}

export default App;