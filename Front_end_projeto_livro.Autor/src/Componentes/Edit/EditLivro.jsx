import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link, useNavigate, useParams } from "react-router-dom";

export default function EditLivro() {
  const [livro, setLivro] = useState({
    nomeLivro: "",
    isbn: "",
    precoLivro: null,
    idAutor: null,
  });
  const navigate = useNavigate();
  const { id } = useParams();

  const upLivro = async (e) => {
    e.preventDefault();
    console.table(livro);
    await axios.patch(`https://localhost:7189/api/Livro/${id}`, {
      nomeLivro: livro.nomeLivro,
      isbn: livro.isbn,
      precoLivro: livro.precoLivro,
      AutorId: livro.AutorId
    });
    navigate("/");
  };

  useEffect(() => {
   GetLivroPorID();
  }, []);

  const GetLivroPorID = async () => {
    const awnser = await axios.get(`https://localhost:7189/api/Livro/${id}`);
    console.log(awnser.data);
    setLivro({
      nomeLivro: awnser.data.nomeLivro,
      isbn: awnser.data.isbn,
      precoLivro: awnser.data.precoLivro,
      idAutor: awnser.data.idAutor
    });
  };

  function upNomeLivro(evento) {
    setLivro({ ...livro, nomeLivro: evento.target.value });
  }

  function upISBN(evento) {
    setLivro({ ...livro, isbn: evento.target.value });
  }

  function upPrecoLivro(evento) {
    setLivro({ ...livro, precoLivro: evento.target.value });
  }

  function upAutorId(evento) {
    setLivro({ ...livro, AutorId: evento.target.value });
  }

  return (
    <div>
      <h2>Editar Livro</h2>
      <form onSubmit={upLivro}>
        <div className="form-floating mb-1">
          <input
            id="nomeLivro"
            className="form-control"
            type="text"
            onChange={upNomeLivro}
            value={livro.nomeLivro}
            placeholder="Nome do Livro"
          />
          <label className="form-label" htmlFor="nomeLivro">
            Nome do Livro
          </label>
        </div>

        <div className="form-floating mb-1">
          <input
            id="isbn"
            className="form-control"
            type="text"
            onChange={upISBN}
            value={livro.isbn}
            placeholder="ISBN"
          />
          <label className="form-label" htmlFor="isbn">
            ISBN
          </label>
        </div>

        <div className="form-floating mb-1">
          <input
            id="IDAutor"
            className="form-control"
            type="number"
            onChange={upAutorId}
            value={livro.AutorId}
            placeholder="Nome do Autor"
          />
          <label className="form-label" htmlFor="AutorId">
            Nome do Autor
          </label>
        </div>

        <div className="form-floating mb-1">
          <input
            id="precoLivro"
            className="form-control"
            type="number"
            onChange={upPrecoLivro}
            value={livro.precoLivro}
            placeholder="Preço do Livro"
          />
          <label className="form-label" htmlFor="precoLivro">
            Preço do Livro
          </label>
        </div>

        <div className="mt-2">
          <button className="btn btn-primary me-2" type="submit">
            Guardar
          </button>
          <Link to={"/"} className="btn btn-secondary">
            Cancelar
          </Link>
        </div>
      </form>
    </div>
  );
}
