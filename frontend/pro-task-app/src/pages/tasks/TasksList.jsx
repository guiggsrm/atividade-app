import React from 'react'
import TaskItem from './TaskItem';

export default function TaskList(props) {
  return (
    <div className="mt-3 row row-cols-2">
        {props.tasks.map(task => (
            <TaskItem 
              task={task} 
              removeTask={props.removeTask} 
              editTask={props.editTask} 
              key={task.id} />
        ))}      
    </div>
  )
}
