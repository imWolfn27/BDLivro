import { useState, useEffect } from "react";
import axios from "axios";


export default function ShowLivro(props) {
  
  const [LivroId, setIdLivro] = useState(props.LivroId);

  const [livro, setLivro] = useState({
    nomeLivro: "",
    isbn: "",
    precoLivro: ""
  });
  
  useEffect(() => {
    GetLivro(idLivro);
  }, [idLivro]);
  
  const GetLivro = async (LivroId) => {
    const awnser = await axios.get(`http://localhost:5000/api/Livro/${LivroId}`);
    console.log(awnser.data)
    setLivro({
      nomeLivro: awnser.data.nome_livro,
      isbn: awnser.data.isbn,
      precoLivro: awnser.data.preco_livro
    })
  }

  return (
    <div className="card mb-3">
      <div className="body">
        <h5 className="NomeLivro">Nome do Livro: {livro.nomeLivro}</h5>
        <p className="ISBN">ISBN: {livro.isbn}</p>
        <p className="PrecoLivro">Preço do Livro: {livro.precoLivro}</p>
      </div>
    </div>

  )
}
