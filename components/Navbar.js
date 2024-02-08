import React from "react";
import { NavLink } from "react-router-dom";
 
const Navbar = () => {
    return (
        <div >
        <aside className="sidebar">
          <div className="logo">
            <button className="menu-btn" id="menu-close">
              <i className="bx bx-log-out-circle" />
            </button>
            <i className="bx bx-pulse" />
            <a href="#">Помощник для студента</a>
          </div>
          <div className="menu">
            <h5>Меню</h5>
            <nav>
                
                <ul>
                    
                    
                    
                    <li >
                        <i className="bx bxs-bolt-circle" />
                        <NavLink to="/HTMLTasks" activeStyle>
                            Задачи
                        </NavLink>
                    </li>
                    <li>
                        <i className="bx bx-target-lock" />
                        <NavLink to="/HTMLTargets" activeStyle>
                            Цели
                        </NavLink>
                    </li>
                    <li>
                        <i className="bx bx-child" />
                        <NavLink to="/HTMLContacts" activeStyle>
                        Контакты
                        </NavLink>
                    </li>
                    
                    </ul>
                
            </nav>
            
          </div>
          <div className="playing">
            <div className="top">
              <button className="supp-btn" id="" />
              <h4 href="#">Обратная связь</h4>
            </div>
            <div className="bottom">
              <i className="bx bx-podcast" />
            </div>
          </div>
        </aside>
            
        </div> 
    );
};
 
export default Navbar;