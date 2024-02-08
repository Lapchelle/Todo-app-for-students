import React from "react";
import img from "./images/profile.png"

 
const Right = () => {
    return (
        <div className="right-section">
      <div className="profile">
        <i className="bx bxs-bell" />
        <i className="bx bxs-cog" />
        <div className="user">
          <div className="left">
            <img src={img }/>
          </div>
          <div className="right">
            <h5>аНОНИМ</h5>
          </div>
        </div>
      </div>
    </div>
    );
};
 
export default Right;