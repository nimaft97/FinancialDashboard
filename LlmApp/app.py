from transformers import TFT5ForConditionalGeneration, T5Tokenizer
from flask import Flask, request, jsonify

MODEL_NAME = "t5-small"


# initialize the model and the tokentizer using "t5-small" which is 
# a light-weight LLM, suitable for converting natural language to structured output
model_name = MODEL_NAME
tokenizer = T5Tokenizer.from_pretrained(model_name)
model = TFT5ForConditionalGeneration.from_pretrained(model_name)

# initialize the Flast application
app = Flask(__name__)

# route the post request as a RESTful API
@app.route('/generate_sql', methods=['POST'])
def generate_sql():
    data = request.json
    user_input = data['text']  # User input from C#

    # Prepare the input for the model
    input_ids = tokenizer.encode(user_input, return_tensors='pt')
    outputs = model.generate(input_ids, max_length=512)
    sql_query = tokenizer.decode(outputs[0], skip_special_tokens=True)
    
    return jsonify({'sql_query': sql_query})

if __name__ == "__main__":
    app.run(host='0.0.0.0', port=5000)





