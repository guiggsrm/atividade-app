import React from 'react'
import Atividade from './Atividade';

export default function AtividadesLista(props) {
  return (
    <div className="mt-3 row row-cols-2">
        {props.atividades.map(atividade => (
            <Atividade 
              atividade={atividade} 
              deletarAtividade={props.deletarAtividade} 
              editarAtividade={props.editarAtividade} 
              key={atividade.id} />
        ))}      
    </div>
  )
}
