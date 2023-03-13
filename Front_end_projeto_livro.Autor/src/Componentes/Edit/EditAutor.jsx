import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link, useNavigate, useParams } from "react-router-dom";

 export default function EditAutor() {
   const [autor, setAutor] = useState({
     NomeAutor: ""
  });
   const navigate = useNavigate();
   const { Id } = useParams();

   const upAutor = async (e) => {
     e.preventDefault();
     await axios.patch(`http://localhost:5000/api/AutorDTOes/${id}`, {
       nome_autor: autor.NomeAutor
    });
     navigate("/EditAutor");
   };

   useEffect(() => {
     GetAutorByID();
   }, []);

  const GetAutorByID = async () => {
     const awnser = await axios.get(`http://localhost:5000/api/AutorDTOes${id}`);

     setAutor({
      NomeAutor: awnser.data.nome_autor
     })
   };

   function upNomeAutor(evento) {
     setAutor({ ...autor, NomeAutor: evento.target.value });
   }

   return (
     <div>
       <h2>Editar Autor!</h2>
       <form onSubmit={upAutor}>
         <div className="mb-3">
           <label className="form-label">Nome do Autor:</label> 
           <input className="form-control"
             type="text"
             onChange={upNomeAutor}
             value={autor.NomeAutor}
           />
          <label className="form-label" htmlFor="nomeAutor">
            Nome do Autor
          </label>
         </div>

         <div>
           <button className="btn btn-primary me-2">Atualizar!</button>
           <Link to={"/EditAutor"} className="btn btn-secondary">Cancelar!</Link>
         </div>
       </form>
     </div>
   );
 }