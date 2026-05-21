---
aliases: [HTML (HyperText Markup Language), HyperText Markup Language]
tags: Techniek
---
# HyperText Markup Language
A _markup_ language is a computer language that defines the structure and presentation of raw text. In [[HTML]], the raw text is wrapped in HTML elements. Related: [[CSS]] for high-level styling. 

## Tags
### Structural
- `<!DOCTYPE html>` (Self-closing) tells the browser what type of document to expect, in this case whichever version of [[HTML]] is the current standard. Must be first line in file. 
- `<html>` Only content between the opening and closing *html* tags will be interpreted as [[HTML]] code. 
	- `<head>` contains metadata for the web page
		- `<title>` Page title (shown in tab/bar)
	- `<body>` Only content between the opening and closing *body* tags can be displayed on the screen.

### Enveloping
- `<!-- -->` opening and closing tags for comments. Text between these tags will not be displayed or executed. 
- `<h1-6>` Headings are (sub-)titles in a text. *H1* is the largest, and *h6* is the smallest.
- `<p>` contains a block of plain text.
- `<div>` 'division' or container that divides the page into sections. They don't inherently have a visual representation, but can be styled. 
- `<span>` contains short pieces of text or other HTML. (Best used to target a specific piece of *inline* content.)
- `<em>` emphasizes text (typically *italic*)
- `<strong>` highlights important text (typically **bold**)
- `<ul>` unordered list
	- `<li>` list item
- `<ol>` ordered list
	- `<li>` list item
- `<video>` embeds a video file on the webpage. Alt text is between the tags. 
	- `src="video-location.mp4"` ***required*** attribute specifying video location (filepath or [[URL]])
	- `width="100"` & `height="240"` specify (override) size
	- `controls` add [[UI]] controls overlay
- `<a>` link to other page. Link text between tags.
	- `href="URL"` (hyperlink reference) to point to other webpage. 
	  Path can be relative, such as `./index.html` (index.html file in current folder), or internal, such as `#introduction` to go to the item with `id="introduction"`
	- `target="_blank"` specify how a link should open. `_blank` opens the link in a new window. In modern browsers, it opens in a new tab instead.
- `<table>` make a table.
	- `<thead>` optional element to contain all table headings
		- `<tr>` table row
			- `<th>` table heading
				- `scope="col"` column heading
				- `scope="row"` row heading
	- `<tbody>` optional element to contain all data excl. headings.
		- `<tr>` table row
			- `<td>` table data
				- `colspan="2"` data spans two columns ( $\to$ )
				- `rowspan="2"` data spans two rows ( $\downarrow$ )
	- `<tfoot>` optional footer row

### Self-closing
- `<br>` Line break (enter). 
- `<img>` Image
	- `src="image-location.jpg"` ***required*** attribute specifying image location (filepath or [[URL]])
	- `alt="descriptive text"` alternative text to use if image display does not work, for screen reading software, and for [[SEO]].
	- `width="100"` & `height="240"` specify (override) size

### Generic attributes
- `id="string"` 