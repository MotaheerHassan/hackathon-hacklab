const AddDetails = () => {
    return (
        <div>
            <form>
                <label htmlFor="name">Name</label>
                <input type="text" placeholder="Enter Name" id="name" name="name" />
                <label htmlFor="empId">Employee Id</label>
                <input type="text" placeholder="Enter Employee Id" id="empId" name="empId"/>
                <label>Email Id</label>
                <input type="email" placeholder="Enter Email" id="email" name="email"/>
                <label>Gender</label>
                <input type="text" placeholder="Enter Gender" id="gender" name="gender"/>
                <label htmlFor="currDesg">Current Designation</label>
                <input type="text" placeholder="Enter Current Designation" name="currDesg"/>
                <label>Years Of Experience</label>
                <input type="text" placeholder="Enter Years of Experience"/>
                <label htmlFor="ttwo">Tech/Tools Worked on</label>
                <input type="Enter Tools/ Technology Names" name="ttwo" id="ttwo"/>
                <label htmlFor="aoi">Area of Intrest (or Tech stack want to work on)</label>
                <input type="text" placeholder="Enter Area of Intrest" id="aoi" name="aoi"/>
            </form>
        </div>
    )
}

export default AddDetails;