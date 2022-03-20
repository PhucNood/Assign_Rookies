import React from "react";
import {useEffect,useState} from "react"
import { Row,Col,Card } from "react-bootstrap";
import axios from "axios";


export  function BookPage(){
      
   const [books,setBooks]= useState([]);
   useEffect(() => {
    axios.get('https://localhost:7040/Book/api/Books',
   )
    .then(function (response) {
        console.log(response.data);
        setBooks(response.data)
    }, []).catch(error => {
        console.log(error);
    });

}, [])

  
    return <div>
         <Row xs={1} md={5} className="g-4">
  {books.map(book => (
    <Col>
      <Card key={book.id}>
        <Card.Img className="col-sm"  variant="top" src={book.image} />
        <Card.Body>
          <Card.Title>{book.bookName}</Card.Title>
          <Card.Text>
         Text
          </Card.Text>
        </Card.Body>
      </Card>
    </Col>
  ))}
</Row>
    </div>
}