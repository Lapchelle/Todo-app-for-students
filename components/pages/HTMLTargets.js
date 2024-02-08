import React, {useState, useEffect} from 'react';
import {AiOutlineDelete} from 'react-icons/ai';
import {BsCheckLg} from 'react-icons/bs';

function Targets  () {
  const [allTargets, setAllTargets] = useState ([]);
  const [newTargetTitle, setNewTargetTitle] = useState ('');
  const [newDescription, setNewDescription] = useState ('');
  const [completedTargets, setCompletedTargets] = useState ([]);
  const [isCompletedScreen, setIsCompletedScreen] = useState (false);

  const handleAddNewTarget = () => {
    let newTargetObj = {
      title: newTargetTitle,
      description: newDescription,
    };
    
    let updatedTargetArr = [...allTargets];
    updatedTargetArr.push (newTargetObj);
    
    setAllTargets (updatedTargetArr);
    localStorage.setItem ('targetlist', JSON.stringify (updatedTargetArr));
    setNewDescription ('');
    setNewTargetTitle ('');
  };

  useEffect (() => {
    let savedTargets = JSON.parse (localStorage.getItem ('targetlist'));
    let savedCompletedTargets = JSON.parse (
      localStorage.getItem ('completedTargets')
    );
    if (savedTargets) {
      setAllTargets (savedTargets);
    }

    if (savedCompletedTargets) {
      setCompletedTargets (savedCompletedTargets);
    }
  }, []);

  const handleTargetDelete = index => {
    let reducedTargets = [...allTargets];
    reducedTargets.splice (index,1);
    // console.log (index);

    // console.log (reducedTodos);
    localStorage.setItem ('targetlist', JSON.stringify (reducedTargets));
    setAllTargets (reducedTargets);
  };

  const handleCompletedTargetDelete = index => {
    let reducedCompletedTargets = [...completedTargets];
    reducedCompletedTargets.splice (index);
    // console.log (reducedCompletedTodos);
    localStorage.setItem (
      'completedTargets',
      JSON.stringify (reducedCompletedTargets)
    );
    setCompletedTargets (reducedCompletedTargets);
  };

  const handleComplete = index => {
    const date = new Date ();
    var dd = date.getDate ();
    var mm = date.getMonth () + 1;
    var yyyy = date.getFullYear ();
    var hh = date.getHours ();
    var minutes = date.getMinutes ();
    var ss = date.getSeconds ();
    var finalDate =
      dd + '-' + mm + '-' + yyyy + ' в ' + hh + ':' + minutes + ':' + ss;

    let filteredTarget = {
      ...allTargets[index],
      completedOn: finalDate,
    };

    // console.log (filteredTodo);

    let updatedCompletedList = [...completedTargets, filteredTarget];
    console.log (updatedCompletedList);
    setCompletedTargets (updatedCompletedList);
    localStorage.setItem (
      'completedTargets',
      JSON.stringify (updatedCompletedList)
    );
    // console.log (index);

    handleTargetDelete (index);
  };
  return (
    <div >
    
      <main>
        <header>
          <form className="new-task-form">

            <div className="search">
            <div className="todo-input-item">
              
              <input
                type="text"
                value={newTargetTitle}
                name="new-task-input"
                id="new-task-input"
                onChange={e => setNewTargetTitle (e.target.value)}
                placeholder="Введите название новой цели"
              />
            </div>
            
          </div>
          <div className="todo-button">
              <button
                className="new-task-submit"
                type="submit"
                onClick={handleAddNewTarget}
                id="new-task-submit"
              >
                Добавить
              </button>
            </div>
          </form>
        </header>
        
        <div className="btn-area">
          <button
            className={`secondaryBtn ${isCompletedScreen === false && 'active'}`}
            onClick={() => setIsCompletedScreen (false)}
          >
            В процессе
          </button>
          <button
            className={`secondaryBtn ${isCompletedScreen === true && 'active'}`}
            onClick={() => setIsCompletedScreen (true)}
          >
            Завершенные
          </button>
        </div>
        <div className="task-list">

          {isCompletedScreen === false &&
            allTargets.map ((item, index) => (
              <div className="todo-list-item" key={index}>
                <div>
                  <h3>{item.title}</h3>
                  <p>{item.description}</p>

                </div>
                <div>
                  <AiOutlineDelete
                    title="Delete?"
                    className="icon"
                    onClick={() => handleTargetDelete (index)}
                  />
                  <BsCheckLg
                    title="Completed?"
                    className=" check-icon"
                    onClick={() => handleComplete (index)}
                  />
                </div>
              </div>
            ))}

          {isCompletedScreen === true &&
            completedTargets.map ((item, index) => (
              <div className="todo-list-item" key={index}>
                <div>
                  <h3>{item.title}</h3>
                  <p>{item.description}</p>
                  <p> <i>Сделано: {item.completedOn}</i></p>
                </div>
                <div>
                  <AiOutlineDelete
                    className="icon"
                    onClick={() => handleCompletedTargetDelete (index)}
                  />
                </div>
              </div>
            ))}
        </div>
      
    </main>
    
  
  </div>
  )
};

export default Targets;
