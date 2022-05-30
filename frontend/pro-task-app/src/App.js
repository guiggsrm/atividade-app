import { useEffect, useState } from 'react';
import { Button, Modal } from 'react-bootstrap'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlus, faCheck, faCancel } from '@fortawesome/free-solid-svg-icons'
import './App.css';
import TaskForm from './components/TaskForm';
import TaskList from './components/TasksList';
import api from './api/tasks';

const initialTask = {
    id: 0,
    title: '',
    description: '',
    priority: 0
};

function App() {

    const [tasks, setTasks] = useState([]);
    const [task, setTask] = useState(initialTask);
    const [show, setShow] = useState(false);
    const [showRemove, setShowRemove] = useState(false);

    const toggleModal = () => setShow(!show);
    const toggleRemoveModal = () => setShowRemove(!showRemove);

    const getTasks = async () => {
        const response = await api.get('tasks');
        return response.data;
    };

    useEffect(() => {
        const getAll = async () => {
            const allTasks = await getTasks();
            if (allTasks) setTasks(allTasks);
        }
        getAll();
    }, []);

    const newTask = async (task) => {
        setTask(initialTask);
        toggleModal();
    }

    const addTask = async (task) => {
        const response = await api.post('tasks', task);
        console.log(response.data);
        setTasks([...tasks, response.data]);
        setTask({id:0});
        toggleModal();
    }

    const modalRemove = (id) => {
        const task = tasks.filter(task => task.id === id);
        setTask(task[0]);
        toggleRemoveModal();
    }

    const removeTask = async (id) => {
        if (await api.delete(`tasks/${id}`)) {
            const tasksFiltradas = tasks.filter(task => task.id !== id);
            setTasks([...tasksFiltradas]);
            if(task.id === id){
                setTask(initialTask);
                toggleRemoveModal();
            }
        }
    }

    const editTask = (id) => {
        const task = tasks.filter(task => task.id === id);
        setTask(task[0]);
        toggleModal();
    }

    const updateTask = async (ativ) => {
        const response = await api.put(`tasks/${ativ.id}`, ativ);
        console.log(response.data);
        setTasks(tasks.map(item => item.id === response.data.id ? response.data : item));
        setTask(initialTask);
        toggleModal();
    }

    const cancelTask = () => {
        setTask(initialTask);
        toggleModal();
    }

    return (
        <>
            <div className="d-flex justify-content-between align-items-end mt-2 pb-3 border-bottom border-dark">
                <h1>Tasks</h1>
                <Button variant="outline-primary" onClick={newTask}>
                    <FontAwesomeIcon icon={faPlus} className="me-2" />New task
                </Button>
            </div>

            <TaskList 
                tasks={tasks} 
                removeTask={modalRemove} 
                editTask={editTask} />

            <Modal show={show} onHide={toggleModal}>
                <Modal.Header closeButton>
                <Modal.Title><h1>{task.id === 0 ? "Add task" : "Task " + task.id}</h1></Modal.Title>
                </Modal.Header>
                <Modal.Body>                    
                    <TaskForm 
                        addTask={addTask} 
                        updateTask={updateTask} 
                        cancelTask={cancelTask} 
                        initialTask={initialTask}
                        selectedTask={task} 
                        tasks={tasks} />
                </Modal.Body>
            </Modal>

            <Modal show={showRemove} onHide={toggleRemoveModal}>
                <Modal.Header closeButton>
                <Modal.Title><h1>Confirm</h1></Modal.Title>
                </Modal.Header>
                <Modal.Body>    
                    <p>Do you want to remove the task {task.id + " - " + task.title}</p>                
                    <Button variant="success me-2" onClick={() => removeTask(task.id)}>
                        <FontAwesomeIcon icon={faCheck} className="me-2" />Yes
                    </Button>
                    <Button variant="outline-danger" onClick={toggleRemoveModal}>
                        <FontAwesomeIcon icon={faCancel} className="me-2" />No
                    </Button>
                </Modal.Body>
            </Modal>
        </>
    );
}

export default App;
