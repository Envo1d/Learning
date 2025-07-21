package main

import (
	"fmt"
	"net/http"
	"time"

	"github.com/Envo1d/itbookworm/internal/data"
)

func (app *application) createBookHandler(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "create a new book")
}

func (app *application) showBookHandler(w http.ResponseWriter, r *http.Request) {
	id, err := app.readIDParam(r)
	if err != nil {
		http.NotFound(w, r)
		return
	}

	book := data.Book{
		ID:        id,
		CreatedAt: time.Now(),
		Title:     "Effective Concurrency in Go",
		Author:    "Burak Serdar",
		Tags:      []string{"go", "programming", "concurrency"},
		Pages:     195,
	}

	err = app.writeJSON(w, http.StatusOK, envelope{"book": book}, nil)
	if err != nil {
		app.logger.Println(err)
		http.Error(w, "The server could not process your request", http.StatusInternalServerError)
	}
}
