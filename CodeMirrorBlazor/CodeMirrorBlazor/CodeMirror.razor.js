import { EditorView, basicSetup, javascript } from "./dist/main.js"

export function load(element) {
    return new EditorView({
        extensions: [basicSetup, javascript()],
        parent: element
    });
}