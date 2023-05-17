import { useRef } from "react";

import "./index.css"
import { createJob } from "../api/apiEndpoints";


export default function CreateTranslationJob({onCreated}: {onCreated: () => any}){  
  const customerNameRef = useRef<HTMLInputElement>(null);
  const originalContentRef = useRef<HTMLInputElement>(null);
  const translatedContentRef = useRef<HTMLInputElement>(null);

  const doSubmit = async () => {
    await createJob({
      customerName: customerNameRef.current?.value as string,
      originalContent: originalContentRef.current?.value as string,
      translatedContent: translatedContentRef.current?.value as string
    });
    onCreated();
  }

  return (
    <form className="createTransactionJob">
      <div>
        Customer name: <input type="text" name="CustomerName" ref={customerNameRef}></input>
      </div>
      <div>
        Original content: <input type="text" name="OriginalContent" ref={originalContentRef}></input>
      </div>
      <div>
        Translated content: <input type="text" name="TranslatedContent" ref={translatedContentRef}></input>
      </div>
      <div>
        <input type="button" value="create job" onClick={(e) => {
          e.preventDefault();
          doSubmit();
          return false;
        }}></input>
      </div>
    </form>
  )
}