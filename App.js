import './App.css';
import Targets from './components/pages/HTMLTargets';
import Tasks from './components/pages/HTMLTasks'
import Navbar from "./components/Navbar";
import Contacts from './components/pages/HTMLContacts';
import Right from './components/Right-section';
import {
  BrowserRouter as Router,
  Routes,
  Route,
} from "react-router-dom";
import Login from './components/Login';
import MainPage from './MainPage';


function App() {
  
  return (
    <Router>
     
        <Navbar />
            
            <Routes>
                
                
                <Route path="/" element={<Tasks />} />
                <Route path="/HTMLTasks" element={<Tasks />} />
                <Route path="/HTMLTargets" element={<Targets />} />
                <Route
                    path="/HTMLContacts"
                    element={<Contacts />}
                />
            </Routes>
            <Right />
      
      
    </Router>
    

  )
    
}

export default App;
