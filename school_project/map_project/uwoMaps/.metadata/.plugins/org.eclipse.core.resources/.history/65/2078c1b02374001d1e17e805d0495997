package uwoMaps;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.ZonedDateTime;
import java.time.format.DateTimeFormatter;

import org.apache.http.HttpEntity;
import org.apache.http.HttpStatus;
import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.utils.URIBuilder;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.apache.http.util.EntityUtils;
import org.json.JSONArray;
import org.json.JSONObject;

/**
 * @author Dayton Crombie, dcrombie@uwo.ca with code from Visual Crossing Timeline API integration
 * @version 1.1
 * This class will be used to get the current weather via API
 */


public class Weather {
	
	/**
	 * Pull data from API and put into JSON file
	 * @return
	 * @throws Exception
	 */
	public static double[] getWeather() throws Exception {
		//set up the end point
		String apiEndPoint = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/";
		String location = "London,ON";
		String startDate = getCurrentDate();
		String endDate = getCurrentDate();
		
		String unitGroup = "metric";
		String apiKey = "VVWHKX5272F37ZT2MWY3FWF24";
	
		StringBuilder requestBuilder = new StringBuilder(apiEndPoint);
		requestBuilder.append(URLEncoder.encode(location, StandardCharsets.UTF_8.toString()));
		
		if (startDate!=null && !startDate.isEmpty()) {
			requestBuilder.append("/").append(startDate);
			if (endDate!=null && !endDate.isEmpty()) {
				requestBuilder.append("/").append(endDate);
			}
		}
		
		URIBuilder builder = new URIBuilder(requestBuilder.toString());
		builder.setParameter("unitGroup", unitGroup)
			.setParameter("key", apiKey);

		HttpGet get = new HttpGet(builder.build());
		
		CloseableHttpClient httpclient = HttpClients.createDefault();
		
		CloseableHttpResponse response = httpclient.execute(get);    
		
		String rawResult = null;
		try {
			if (response.getStatusLine().getStatusCode() != HttpStatus.SC_OK) {
				System.out.printf("Bad response status code:%d%n", response.getStatusLine().getStatusCode());
				return null;
			}
			
			HttpEntity entity = response.getEntity();
		    if (entity != null) {
		    	rawResult = EntityUtils.toString(entity, Charset.forName("utf-8"));
		    }
		    
		} finally {
			response.close();
		}
		double[] temps = searchJSON(rawResult);
		return temps;
	}
	
	/**
	 * Get data from JSON file
	 * @param rawResult
	 * @return
	 */
	private static double[] searchJSON(String rawResult) {
		
		double[] temps = new double[2];
		
		if (rawResult == null || rawResult.isEmpty()) {
			return null;
		}
		JSONObject timelineResponse = new JSONObject(rawResult);
		ZoneId zoneId = ZoneId.of(timelineResponse.getString("timezone"));
		JSONArray values = timelineResponse.getJSONArray("days");
		for (int i = 0; i < values.length(); i++) {
			JSONObject dayValue = values.getJSONObject(i);
            ZonedDateTime datetime = ZonedDateTime.ofInstant(Instant.ofEpochSecond(dayValue.getLong("datetimeEpoch")), zoneId);
            temps[0] = dayValue.getDouble("tempmin");
            temps[1] = dayValue.getDouble("tempmax");
        }
		return temps;
	}
	
	/**
	 * Gets the current data
	 * @return
	 */
	private static String getCurrentDate() {
		DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy-MM-dd");  
		LocalDateTime now = LocalDateTime.now();
		return dtf.format(now); 
	}
}