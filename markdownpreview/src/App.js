import './App.css';
import { useState } from "react";
import {marked} from "marked";
import DOMPurify from 'dompurify';

marked.setOptions({
  breaks: true,
});

function App() {
  const [editorContent, setEditorContent] = useState(
`# Markdown Previewer
## Sub-heading
[link](https://wikimedia.org)
\`<div>Code</div>\`
\`\`\`
<div>Code Block</div>
\`\`\` 
- list item
- list item
> Blockquote
![Markdown logo](https://upload.wikimedia.org/wikipedia/commons/thumb/4/48/Markdown-mark.svg/1200px-Markdown-mark.svg.png)
**bolded text**`);

  function handleEditorChange(event) {
    setEditorContent(event.target.value);
  }

  function getMarkdownText() {
    var rawMarkup = marked(editorContent);
    var sanitizedHTML = DOMPurify.sanitize(rawMarkup);
    return { __html: sanitizedHTML };
  }


  return (
    <div className="App">
      <div id="quote-box" className="quote-box">
        <div className='Container'>
          <textarea id="editor" className="text input" value={editorContent} onChange={handleEditorChange} />
        </div>
        <div className='Container'>
          <div id="preview" className="text output" dangerouslySetInnerHTML={getMarkdownText()} ></div>
        </div>
      </div>
    </div>
  )
}

export default App;
