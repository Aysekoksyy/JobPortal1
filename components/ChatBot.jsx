import { useState } from 'react';

function ChatBot() {
  const [messages, setMessages] = useState([]);
  const [userInput, setUserInput] = useState('');
  const [error, setError] = useState(null);

  const sendMessage = async () => {
    if (!userInput.trim()) return;

    // Kullanıcı mesajı ekleniyor
    const updatedMessages = [...messages, { from: 'user', text: userInput }];
    setMessages(updatedMessages);
    setUserInput('');
    setError(null);

    try {
      const response = await fetch('http://localhost:5169/api/chatbot', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ message: userInput }),
      });

      if (!response.ok) throw new Error('Sunucu yanıt vermedi');

      const data = await response.json();
      setMessages([...updatedMessages, { from: 'bot', text: data.reply }]);
    } catch (err) {
      setMessages([
        ...updatedMessages,
        { from: 'bot', text: '❌ Cevap alınamadı. API çalışıyor mu?' },
      ]);
      setError(err.message);
    }
  };

  return (
    <div style={{ maxWidth: '500px', margin: '40px auto', border: '1px solid #ccc', padding: '20px', borderRadius: '10px' }}>
      <h2 style={{ textAlign: 'center' }}>💬 ChatBot</h2>

      <div style={{ height: '250px', overflowY: 'auto', marginBottom: '10px', background: '#f9f9f9', padding: '10px' }}>
        {messages.map((msg, idx) => (
          <div key={idx} style={{ textAlign: msg.from === 'user' ? 'right' : 'left', margin: '8px 0' }}>
            <p><strong>{msg.from === 'user' ? 'Sen' : 'Bot'}:</strong> {msg.text}</p>
          </div>
        ))}
      </div>

      <input
        type="text"
        value={userInput}
        placeholder="Mesaj yaz..."
        onChange={(e) => setUserInput(e.target.value)}
        onKeyDown={(e) => e.key === 'Enter' && sendMessage()}
        style={{ width: '80%', padding: '10px' }}
      />
      <button onClick={sendMessage} style={{ padding: '10px', marginLeft: '5px' }}>
        Gönder
      </button>

      {error && <p style={{ color: 'red', marginTop: '10px' }}>⚠️ Hata: {error}</p>}
    </div>
  );
}

export default ChatBot;
