import React from "react";
import {useEffect,useState} from "react"
import { Row,Col,Card } from "react-bootstrap";
import axios from "axios";


export  function BookPage(){
      
   const [books,setBooks]= useState([]);
   useEffect(() => {
    axios.get("https://localhost:7040/Book/api/Books"
    ,{ headers: { 'Content-Type': 'application/x-www-form-urlencoded' },}
    ).then(function (response) {
        console.log(response);
    }, []).catch(error => {
        console.log(error);
    });

}, [])
    return <div>
         <Row xs={1} md={5} className="g-4">
  {Array.from({ length: 16 }).map((_, idx) => (
    <Col>
      <Card>
        <Card.Img variant="top" src="" />
        <Card.Body>
          <Card.Title>Lua chua</Card.Title>
          <Card.Text>
           Rac ruoi
          </Card.Text>
        </Card.Body>
      </Card>
    </Col>
  ))}
</Row>
    </div>
}