import React, { useState } from "react";
import axios from "axios";
import { Link, useNavigate } from "react-router-dom";

 export default function Add_Autor() {
   const [autor, setAutor] = useState({
     nomeAutor: ""
   });
   const navigate = useNavigate();

   const saveAutor = async (e) => {
     e.preventDefault();
     await axios.post ('https://localhost:7189/api/AutorDTOes', {
       "nome_Autor": autor.nomeAutor
     });
     navigate("/por aqui outra coisa")
   }

   function upNomeAutor(evento){
     setAutor({...autor, nomeAutor:evento.target.value})
   }

   return (
     <div>
       <h2>Adicionar Autor!</h2>
       <form onSubmit={saveAutor}>
         <div>
           <label className="form-label">Nome do Autor:</label>
           <input className="form-control" type="text" onChange={upNomeAutor} value={autor.nomeAutor}/>
         </div>
       </form>
    </div>
   )
 }