package data

import "time"

type Book struct {
	ID        int64     `json:"id"`
	CreatedAt time.Time `json:"-"`
	Author    string    `json:"author"`
	Title     string    `json:"title"`
	Year      int32     `json:"year,omitempty"`
	Tags      []string  `json:"tags,omitempty"`
	Pages     Pages     `json:"pages,omitempty"`
}
